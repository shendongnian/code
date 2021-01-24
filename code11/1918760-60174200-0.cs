    using UnityEngine;
    using System.Collections;
    using Vuforia;
    using UnityEngine.UI;
    public class VuforiaCamAccess : MonoBehaviour
    {
        private bool mAccessCameraImage = true;
        public RawImage rawImage;
        public GameObject Mesh;
        private Texture2D texture;
    #if UNITY_EDITOR
        private Vuforia.PIXEL_FORMAT mPixelFormat = Vuforia.PIXEL_FORMAT.GRAYSCALE;
    #else
        private Vuforia.PIXEL_FORMAT mPixelFormat =  Vuforia.PIXEL_FORMAT.RGB888;
    #endif
        private bool mFormatRegistered = false;
        void Start()
        {
    #if UNITY_EDITOR
            texture = new Texture2D(Screen.width, Screen.height, TextureFormat.R8, false);
    #else
            texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    #endif
            // Register Vuforia life-cycle callbacks:
            Vuforia.VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
            Vuforia.VuforiaARController.Instance.RegisterOnPauseCallback(OnPause);
            Vuforia.VuforiaARController.Instance.RegisterTrackablesUpdatedCallback(OnTrackablesUpdated);
        }
        private void OnVuforiaStarted()
        {
            // Try register camera image format
            if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
            {
                Debug.Log("Successfully registered pixel format " + mPixelFormat.ToString());
                mFormatRegistered = true;
            }
            else
            {
                Debug.LogError("Failed to register pixel format " + mPixelFormat.ToString() +
                    "\n the format may be unsupported by your device;" +
                    "\n consider using a different pixel format.");
                mFormatRegistered = false;
            }
        }
        private void OnPause(bool paused)
        {
            if (paused)
            {
                Debug.Log("App was paused");
                UnregisterFormat();
            }
            else
            {
                Debug.Log("App was resumed");
                RegisterFormat();
            }
        }
        private void OnTrackablesUpdated()
        {
            //skip if still loading image to texture2d
            if (LoadingTexture) return;
            if (mFormatRegistered)
            {
                if (mAccessCameraImage)
                {
                    Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);
                    //if (image != null && image.IsValid())
                    if (image != null)
                    {
                        byte[] pixels = image.Pixels;
                        int width = image.Width;
                        int height = image.Height;
                        StartCoroutine(SetTexture(pixels, width, height));
                    }
                }
            }
        }
        bool LoadingTexture = false;
        IEnumerator SetTexture(byte[] pixels, int width, int height)
        {
            if (!LoadingTexture)
            {
                LoadingTexture = true;
                if (pixels != null && pixels.Length > 0)
                {
                    if (texture.width != width || texture.height != height)
                    {
    #if UNITY_EDITOR
                        texture = new Texture2D(width, height, TextureFormat.R8, false);
    #else
                        texture = new Texture2D(width, height, TextureFormat.RGB24, false);
    #endif
                    }
                    texture.LoadRawTextureData(pixels);
                    texture.Apply();
                    if (rawImage != null)
                    {
                        rawImage.texture = texture;
                        rawImage.material.mainTexture = texture;
                    }
                    if (Mesh != null) Mesh.GetComponent<Renderer>().material.mainTexture = texture;
                }
                yield return null;
                LoadingTexture = false;
            }
        }
        private void UnregisterFormat()
        {
            Debug.Log("Unregistering camera pixel format " + mPixelFormat.ToString());
            CameraDevice.Instance.SetFrameFormat(mPixelFormat, false);
            mFormatRegistered = false;
        }
        private void RegisterFormat()
        {
            if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
            {
                Debug.Log("Successfully registered camera pixel format " + mPixelFormat.ToString());
                mFormatRegistered = true;
            }
            else
            {
                Debug.LogError("Failed to register camera pixel format " + mPixelFormat.ToString());
                mFormatRegistered = false;
            }
        }
    }
