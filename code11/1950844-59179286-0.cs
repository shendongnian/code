    using System;
    using System.Threading;
    using UnityEngine;
    
    public static class PanoramicToCubemapRuntimeConverter
    {
    
        //SAFETY PARAMETERS
        private static byte SAFETY_MaximumSupersampling = 16;
        private static int SAFETY_MaximumCubemapResolution = 4096;
        private static bool SAFETY_OVERRIDE = false;
    
        //Runtime
        /// <summary>
        /// The ComputeShader that actually does the bulk of the work to convert the panoramic texture to a cubemap.
        /// </summary>
        private static ComputeShader panoramicImageToCubeMapShader;
    
        /// <summary>
        /// This is not actually used anywhere, but still, if you need it, you can use it. it's the sin of 45 degrees (obviously calculator was set to degrees for this, and not radians).
        /// </summary>
        public const double sin45deg = 0.70710678118654752440084436210485;
    
    
        private static void AssignComputeShader()
        {
            panoramicImageToCubeMapShader = Resources.Load<ComputeShader>("PanoramicToCubemapConverter");
        }
    
        public static void AllowUnsafe(bool set)
        {
            SAFETY_OVERRIDE = set;
        }
    
        /// <summary>
        /// Converts a panoramic texture into a cubemap texture. computing may take from 1 to 60 seconds on a mid-range computer based on settings. This process is bottlenecked mostly by CPU single thread processing power (i tried multithreading but unity doesn't like it... errors when trying to modify textures on other threads) and RAM bandwidth.
        /// </summary>
        /// <param name="panoramicTexture">the texture (possibly panoramic) to convert to cubemap. Better if PoT.</param>
        /// <param name="cubemapResolution">the resolution the cubemap will have (6 square textures with that resolution). Pot values are preferrable. Higher values increase a lot the cpu strain and in a lesser way gpu strain. Has the largest impact on processing time. WARNING: VALUES LARGER THAN 4096 MIGHT FREEZE YOUR COMPUTER SEVERELY AND POTENTIALLY REUQUIRE FORCED REBOOT IF IT DOES NOT HAVE A LARGE AMOUNT OF RAM (16+ GB).</param>
        /// <param name="superSamplingLevel">how many times the computed texture is larger than the cubemap resolution. Higher values are better. You are not forced to use PoT values. Higher values increase VRAM usage and require a better GPU. WARNING: VALUES HIGHER THAN 16 MIGHT FREEZE YOUR COMPUTER COMPLETELY, MOUSE, KEYBOARD, WINDOWS, AND MIGHT REQUIRE A FORCED REBOOT.</param>
        /// <param name="cubeMapFormat">the color format the cubemap will be used in. default RGBA32. higher values require higher bandwidth (RAM & VRAM), and affect both CPU and GPU.</param>
        /// <param name="generateMipMaps">generate mipmaps for the cubemap?</param>
        /// <returns>a cubemap created starting from a panoramic texture.</returns>
        public static Cubemap ConvertPanoramaTextureToCubemap(Texture2D panoramicTexture, int cubemapResolution, byte superSamplingLevel = 2, TextureFormat cubeMapFormat = TextureFormat.RGBA32, bool generateMipMaps = true)
        {
            bool useMultiThreading = false; //doesn't work with unity, but i still leave the "prototype" code in.
    
            if (panoramicImageToCubeMapShader == null)
                AssignComputeShader();
    
            bool abort = false;
            if (cubemapResolution > SAFETY_MaximumCubemapResolution)
            {
                Debug.LogWarning("WARNING: Requested Cubemap resolution of " + cubemapResolution + " is larger than the maximum safe parameter of " + SAFETY_MaximumCubemapResolution + ". Values higher than it might freeze your computer's entire OS and require a forced reboot.");
                abort = true;
            }
            if (superSamplingLevel > SAFETY_MaximumSupersampling)
            {
                Debug.LogWarning("WARNING: Requested Cubemap supersampling of " + superSamplingLevel + " is larger than the maximum safe parameter of " + SAFETY_MaximumSupersampling + ". Values higher than it might freeze your computer's entire OS and require a forced reboot.");
                abort = true;
            }
    
            if (abort && SAFETY_OVERRIDE == false)
                throw new Exception("System Protection Exception: Panoramic texture to cubemap texture conversion got aborted because parameters were passing maximum safe parameters for the conversions. if you still want to risk freezing your computer, call 'PanoramicToCubemapRuntimeConverter.AllowUnsafe (true)' before calling the 'PanoramicToCubemapRuntimeConverter.ConvertPanoramaTextureToCubemap ()' function to ignore the safety checks. You are STRONGLY advised to save everything before attempting to do so and to stop any crucial task before running at the moment to reduce damage.\n");
    
            Cubemap convertedTexture = new Cubemap(cubemapResolution, cubeMapFormat, generateMipMaps);
    
            superSamplingLevel = (byte)Mathf.Clamp(superSamplingLevel, 1, 256);
    
            //the format the rendertextures will use, this is necessary because compute shaders can only write to rendertextures.
            //the format is determined by the section below, that gets "the most similar" format to the one that the output cubemap has to be in.
            //formats with less than three colors (such as R16, R8 or RG16) are not supported (by default).
            //if required, though, you can still add the desired format (with the rendertexture format) below.
            RenderTextureFormat usedRendertextureFormat;
    
            switch (cubeMapFormat)
            {
                case TextureFormat.RGBA32: usedRendertextureFormat = RenderTextureFormat.ARGB32; break;
                case TextureFormat.RGBAHalf: usedRendertextureFormat = RenderTextureFormat.ARGBHalf; break;
                case TextureFormat.RGBAFloat: usedRendertextureFormat = RenderTextureFormat.ARGBFloat; break;
                case TextureFormat.RGBA4444: usedRendertextureFormat = RenderTextureFormat.ARGB4444; break;
                case TextureFormat.RGB24: usedRendertextureFormat = RenderTextureFormat.ARGB32; break;
                case TextureFormat.RGB565: usedRendertextureFormat = RenderTextureFormat.RGB565; break;
                default:
                    usedRendertextureFormat = RenderTextureFormat.ARGB32;
                    Debug.LogWarning("Panoramic texture to cubemap texture converter: cubemap format '" + cubeMapFormat + "' can't be converted to a rendertexture equivalent: setting rendertextures as 'ARGB32'.");
                    break;
            }
    
            //create the 6 textures for the 6 faces
            RenderTexture CUBE_Top = RenderTexture.GetTemporary(cubemapResolution * superSamplingLevel, cubemapResolution * superSamplingLevel, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //y = 1
            RenderTexture CUBE_Bottom = RenderTexture.GetTemporary(cubemapResolution * superSamplingLevel, cubemapResolution * superSamplingLevel, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //y = -1
            RenderTexture CUBE_Left = RenderTexture.GetTemporary(cubemapResolution * superSamplingLevel, cubemapResolution * superSamplingLevel, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //x = -1
            RenderTexture CUBE_Right = RenderTexture.GetTemporary(cubemapResolution * superSamplingLevel, cubemapResolution * superSamplingLevel, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //x = 1
            RenderTexture CUBE_Forward = RenderTexture.GetTemporary(cubemapResolution * superSamplingLevel, cubemapResolution * superSamplingLevel, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //z = 1
            RenderTexture CUBE_Backward = RenderTexture.GetTemporary(cubemapResolution * superSamplingLevel, cubemapResolution * superSamplingLevel, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear);  //z = -1
    
            CUBE_Top.enableRandomWrite = true;
            CUBE_Bottom.enableRandomWrite = true;
            CUBE_Left.enableRandomWrite = true;
            CUBE_Right.enableRandomWrite = true;
            CUBE_Forward.enableRandomWrite = true;
            CUBE_Backward.enableRandomWrite = true;
    
            CUBE_Top.Create();
            CUBE_Bottom.Create();
            CUBE_Left.Create();
            CUBE_Right.Create();
            CUBE_Forward.Create();
            CUBE_Backward.Create();
    
    
            //set kernel 0 parameters
            panoramicImageToCubeMapShader.SetTexture(0, "CUBE_Top", CUBE_Top);
            panoramicImageToCubeMapShader.SetTexture(0, "CUBE_Bottom", CUBE_Bottom);
            panoramicImageToCubeMapShader.SetTexture(0, "CUBE_Left", CUBE_Left);
            panoramicImageToCubeMapShader.SetTexture(0, "CUBE_Right", CUBE_Right);
            panoramicImageToCubeMapShader.SetTexture(0, "CUBE_Forward", CUBE_Forward);
            panoramicImageToCubeMapShader.SetTexture(0, "CUBE_Backward", CUBE_Backward);
    
            panoramicImageToCubeMapShader.SetTexture(0, "PanoramicTexture", panoramicTexture);
            panoramicImageToCubeMapShader.SetVector("panoramicResolution", new Vector4((float)panoramicTexture.width, (float)panoramicTexture.height));
            panoramicImageToCubeMapShader.SetInt("cubeMapResolution", cubemapResolution * superSamplingLevel);
    
            //run kernel 0 (panoramic->cubemap transformations)
            panoramicImageToCubeMapShader.Dispatch(0, Mathf.CeilToInt(cubemapResolution * superSamplingLevel / 2.0f), Mathf.CeilToInt(cubemapResolution * superSamplingLevel / 2.0f), 3 /*each handles 2 textures*/);
    
    
    
            //resolve the supersampling
    
            //create proper resolution (render)textures, one for eache face of a cube
            RenderTexture CUBE_Top_Resolved = RenderTexture.GetTemporary(cubemapResolution, cubemapResolution, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //y = 1
            RenderTexture CUBE_Bottom_Resolved = RenderTexture.GetTemporary(cubemapResolution, cubemapResolution, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //y = -1
            RenderTexture CUBE_Left_Resolved = RenderTexture.GetTemporary(cubemapResolution, cubemapResolution, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //x = -1
            RenderTexture CUBE_Right_Resolved = RenderTexture.GetTemporary(cubemapResolution, cubemapResolution, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //x = 1
            RenderTexture CUBE_Forward_Resolved = RenderTexture.GetTemporary(cubemapResolution, cubemapResolution, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear); //z = 1
            RenderTexture CUBE_Backward_Resolved = RenderTexture.GetTemporary(cubemapResolution, cubemapResolution, 0, usedRendertextureFormat, RenderTextureReadWrite.Linear);  //z = -1
    
            CUBE_Top_Resolved.enableRandomWrite = true;
            CUBE_Bottom_Resolved.enableRandomWrite = true;
            CUBE_Left_Resolved.enableRandomWrite = true;
            CUBE_Right_Resolved.enableRandomWrite = true;
            CUBE_Forward_Resolved.enableRandomWrite = true;
            CUBE_Backward_Resolved.enableRandomWrite = true;
    
            CUBE_Top_Resolved.Create();
            CUBE_Bottom_Resolved.Create();
            CUBE_Left_Resolved.Create();
            CUBE_Right_Resolved.Create();
            CUBE_Forward_Resolved.Create();
            CUBE_Backward_Resolved.Create();
    
            //set (compute)shader parameters
            //input textures
            panoramicImageToCubeMapShader.SetTexture(1, "detailed_leftFace", CUBE_Left);
            panoramicImageToCubeMapShader.SetTexture(1, "detailed_rightFace", CUBE_Right);
            panoramicImageToCubeMapShader.SetTexture(1, "detailed_forwardFace", CUBE_Forward);
            panoramicImageToCubeMapShader.SetTexture(1, "detailed_backFace", CUBE_Backward);
            panoramicImageToCubeMapShader.SetTexture(1, "detailed_topFace", CUBE_Top);
            panoramicImageToCubeMapShader.SetTexture(1, "detailed_bottomFace", CUBE_Bottom);
    
            //output textures
            panoramicImageToCubeMapShader.SetTexture(1, "resolved_leftFace", CUBE_Left_Resolved);
            panoramicImageToCubeMapShader.SetTexture(1, "resolved_rightFace", CUBE_Right_Resolved);
            panoramicImageToCubeMapShader.SetTexture(1, "resolved_forwardFace", CUBE_Forward_Resolved);
            panoramicImageToCubeMapShader.SetTexture(1, "resolved_backFace", CUBE_Backward_Resolved);
            panoramicImageToCubeMapShader.SetTexture(1, "resolved_topFace", CUBE_Top_Resolved);
            panoramicImageToCubeMapShader.SetTexture(1, "resolved_bottomFace", CUBE_Bottom_Resolved);
    
            panoramicImageToCubeMapShader.SetInt("superSamplingLevel", (int)superSamplingLevel);
            panoramicImageToCubeMapShader.SetBool("resolve", superSamplingLevel > 1);
    
            //start kernel 1 (antialiasing resolve)
            panoramicImageToCubeMapShader.Dispatch(1, Mathf.CeilToInt(cubemapResolution / 2.0f), Mathf.CeilToInt(cubemapResolution / 2.0f), 3 /*each group has 2 z-threads.*/);
    
    
    
            //copy all pixels of the 6 textures to the cubemap
            if (!useMultiThreading)
            {
    
                //left
                Texture2D CUBE_Left_Cache = GetRenderTexturePixels(CUBE_Left_Resolved); //can't read rendertextures directly like normal textures
                CopyTextureToCubemapFace(CUBE_Left_Cache, ref convertedTexture, CubemapFace.NegativeX, false);
    
                //right
                Texture2D CUBE_Right_Cache = GetRenderTexturePixels(CUBE_Right_Resolved);
                CopyTextureToCubemapFace(CUBE_Right_Cache, ref convertedTexture, CubemapFace.PositiveX, false);
    
                //forward (z = +1)
                Texture2D CUBE_Forward_Cache = GetRenderTexturePixels(CUBE_Forward_Resolved);
                CopyTextureToCubemapFace(CUBE_Forward_Cache, ref convertedTexture, CubemapFace.PositiveZ, false);
    
                //backward (z = -1)
                Texture2D CUBE_Backward_Cache = GetRenderTexturePixels(CUBE_Backward_Resolved);
                CopyTextureToCubemapFace(CUBE_Backward_Cache, ref convertedTexture, CubemapFace.NegativeZ, false);
    
                //up
                Texture2D CUBE_Top_Cache = GetRenderTexturePixels(CUBE_Top_Resolved);
                CopyTextureToCubemapFace(CUBE_Top_Cache, ref convertedTexture, CubemapFace.PositiveY, false);
    
                //down
                Texture2D CUBE_Bottom_Cache = GetRenderTexturePixels(CUBE_Bottom_Resolved);
                CopyTextureToCubemapFace(CUBE_Bottom_Cache, ref convertedTexture, CubemapFace.NegativeY, false);
    
                convertedTexture.Apply(generateMipMaps, false);
    
            }
            else
            {
    
                //Multithreaded code!
                //(not working)
                //Unity does not allow to modify textures from other threads, so while compiling this part throws no error, attempting to run it
                //throws errors that specify that textures can only bbe modified in the main thread.
    
                //also, this is c# multithreading, which is separated from the unity job system (which does not even allow to pass textures as they are reference data types).
                //the time unity allows to modify textures from other threads this (if the code is correct) *MIGHT* work.
    
                //left
                Texture2D CUBE_Left_Cache = GetRenderTexturePixels(CUBE_Left_Resolved);
                CubemapGeneratorThread leftFaceHandler = new CubemapGeneratorThread(CUBE_Left_Cache, convertedTexture, CubemapFace.NegativeX); //set thread parameters
                Thread leftFaceThread = new Thread(new ThreadStart(leftFaceHandler.CopyToFaceWithVerticalFlip)); //create thread
                leftFaceThread.Start(); //start thread
    
                //right
                Texture2D CUBE_Right_Cache = GetRenderTexturePixels(CUBE_Right_Resolved);
                CubemapGeneratorThread rightFaceHandler = new CubemapGeneratorThread(CUBE_Right_Cache, convertedTexture, CubemapFace.PositiveX); //set thread parameters
                Thread rightFaceThread = new Thread(new ThreadStart(rightFaceHandler.CopyToFaceWithVerticalFlip)); //create thread
                rightFaceThread.Start(); //start thread
    
                //forward
                Texture2D CUBE_Forward_Cache = GetRenderTexturePixels(CUBE_Forward_Resolved);
                CubemapGeneratorThread forwardFaceHandler = new CubemapGeneratorThread(CUBE_Forward_Cache, convertedTexture, CubemapFace.PositiveZ); //set thread parameters
                Thread forwardFaceThread = new Thread(new ThreadStart(forwardFaceHandler.CopyToFaceWithVerticalFlip)); //create thread
                forwardFaceThread.Start(); //start thread
    
                //backward
                Texture2D CUBE_Backward_Cache = GetRenderTexturePixels(CUBE_Backward_Resolved);
                CubemapGeneratorThread backwardFaceHandler = new CubemapGeneratorThread(CUBE_Backward_Cache, convertedTexture, CubemapFace.NegativeZ); //set thread parameters
                Thread backwardFaceThread = new Thread(new ThreadStart(backwardFaceHandler.CopyToFaceWithVerticalFlip)); //create thread
                backwardFaceThread.Start(); //start thread
    
                //top
                Texture2D CUBE_Top_Cache = GetRenderTexturePixels(CUBE_Top_Resolved);
                CubemapGeneratorThread topFaceHandler = new CubemapGeneratorThread(CUBE_Top_Cache, convertedTexture, CubemapFace.PositiveY); //set thread parameters
                Thread topFaceThread = new Thread(new ThreadStart(topFaceHandler.CopyToFaceWithVerticalFlip)); //create thread
                topFaceThread.Start(); //start thread
    
                //bottom
                Texture2D CUBE_Bottom_Cache = GetRenderTexturePixels(CUBE_Bottom_Resolved);
                CubemapGeneratorThread bottomFaceHandler = new CubemapGeneratorThread(CUBE_Bottom_Cache, convertedTexture, CubemapFace.NegativeY); //set thread parameters
                Thread bottomFaceThread = new Thread(new ThreadStart(bottomFaceHandler.CopyToFaceWithVerticalFlip)); //create thread
                bottomFaceThread.Start(); //start thread
    
    
                //Wait for all the started threads to complete, with a maximum timeout of 15 seconds.
                leftFaceThread.Join(15);
                rightFaceThread.Join(15);
                forwardFaceThread.Join(15);
                backwardFaceThread.Join(15);
                topFaceThread.Join(15);
                bottomFaceThread.Join(15);
            }
    
            //release high-res textures
            RenderTexture.ReleaseTemporary(CUBE_Top);
            RenderTexture.ReleaseTemporary(CUBE_Bottom);
            RenderTexture.ReleaseTemporary(CUBE_Left);
            RenderTexture.ReleaseTemporary(CUBE_Right);
            RenderTexture.ReleaseTemporary(CUBE_Forward);
            RenderTexture.ReleaseTemporary(CUBE_Backward);
    
            //Release processed supersampling textures
            RenderTexture.ReleaseTemporary(CUBE_Top_Resolved);
            RenderTexture.ReleaseTemporary(CUBE_Bottom_Resolved);
            RenderTexture.ReleaseTemporary(CUBE_Left_Resolved);
            RenderTexture.ReleaseTemporary(CUBE_Right_Resolved);
            RenderTexture.ReleaseTemporary(CUBE_Forward_Resolved);
            RenderTexture.ReleaseTemporary(CUBE_Backward_Resolved);
    
    
            //ok from down here.
    
            return convertedTexture;
        }
    
    
        public static void CopyTextureToCubemapFace(Texture2D texture, ref Cubemap targetCubemap, CubemapFace targetFace, bool applyChanges = true)
        {
            if (texture.height != targetCubemap.height || texture.width != targetCubemap.height)
                throw new Exception("Panoramic to cubemap texture converter: 'CopyTextureToCubemapFace' texture to copy to face is non square or its resolution does not match the target cubemap's resolution.");
    
            targetCubemap.SetPixels(texture.GetPixels(), targetFace);
    
            if (applyChanges)
                targetCubemap.Apply();
        }
    
    
        //From unity manual: https://docs.unity3d.com/ScriptReference/RenderTexture-active.html
        public static Texture2D GetRenderTexturePixels(RenderTexture rt)
        {
            // Remember currently active render texture
            RenderTexture currentActiveRT = RenderTexture.active;
    
            // Set the supplied RenderTexture as the active one
            RenderTexture.active = rt;
    
            // Create a new Texture2D and read the RenderTexture image into it
            Texture2D tex = new Texture2D(rt.width, rt.height);
            tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
    
            // Restorie previously active render texture
            RenderTexture.active = currentActiveRT;
            return tex;
        }
    }
    
    
    
    public class CubemapGeneratorThread
    {
    
        //volatile means the thread will not cache values and write/read them "in batches" to improve performance, but will instead read/write as it goes.
    
        public volatile Texture2D sourceTexture;
        public Vector2Int sourceTextureResolution;
    
        public volatile Cubemap targetCubemap;
        public int cubemapResolution;
    
        public CubemapFace targetFace;
    
    
        /// <summary>
        /// This can only be created properly from the main thread.
        /// </summary>
        public CubemapGeneratorThread(Texture2D source, Cubemap target, CubemapFace copyTargetFace, bool flipVertically = false)
        {
            sourceTexture = source;
            sourceTextureResolution = new Vector2Int(source.width, source.height);
            targetCubemap = target;
            cubemapResolution = targetCubemap.width;
            targetFace = copyTargetFace;
    
            //if (flipVertically)
            //	CopyToFaceWithVerticalFlip ();
            //else
            //	CopyToFace ();
        }
    
    
    
        public void CopyToFace()
        {
            if (cubemapResolution != sourceTextureResolution.x || cubemapResolution != sourceTextureResolution.y)
            {
                throw new Exception("Panoramic texture to cubemap texture generator error: cubemap resolution is different from source texture width or height.");
            }
    
            for (int x = 0; x < cubemapResolution; x++)
            {
                for (int y = 0; y < cubemapResolution; y++)
                {
                    targetCubemap.SetPixel(targetFace, x, y, sourceTexture.GetPixel(x, y));
                }
            }
    
            targetCubemap.Apply();
        }
    
        public void CopyToFaceWithVerticalFlip()
        {
            if (cubemapResolution != sourceTextureResolution.x || cubemapResolution != sourceTextureResolution.y)
            {
                throw new Exception("Panoramic texture to cubemap texture generator error: cubemap resolution is different from source texture width or height.");
            }
    
            for (int x = 0; x < cubemapResolution; x++)
            {
                for (int y = 0; y < cubemapResolution; y++)
                {
                    targetCubemap.SetPixel(targetFace, cubemapResolution - x, cubemapResolution - y, sourceTexture.GetPixel(x, y));
                }
            }
    
            targetCubemap.Apply();
        }
    
        public void ApplyChangesToTexture()
        {
            targetCubemap.Apply();
        }
    }
    
    
    /*
    public struct CubemapGenerator : IJobParallelFor {
    
    	public IntPtr leftFacePtr;
    
    
    	public void Execute (int index) {
    		if (index == 0)
    			leftFace.SetPixel (1, 1, Color.red);
    		
    	}
    }*/
    
    /*public struct TextureContainer {
    	public Texture2D val;
    
    	public TextureContainer (Texture2D texture) {
    		val = texture;
    	}
    }*/
