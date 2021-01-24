    using UnityEngine;
    using UnityEngine.UI;
    
    public class Resizer : MonoBehaviour {
        public Texture2D inputtexture2D;
        public RawImage rawImage;
        [ExposeMethodInEditor]
        void Start()
        {
            rawImage.texture=Resize(inputtexture2D,200,100);
        }
        Texture2D Resize(Texture2D texture2D,int targetX,int targetY)
        {
            RenderTexture rt=new RenderTexture(targetX, targetY,24);
            RenderTexture.active = rt;
            Graphics.Blit(texture2D,rt);
            Texture2D result=new Texture2D(targetX,targetY);
            result.ReadPixels(new Rect(0,0,targetX,targetY),0,0);
            result.Apply();
            return result;
        }
    }
