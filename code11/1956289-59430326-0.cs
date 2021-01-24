c#
using System.IO;
using UnityEngine;
public class RunTimeScreenshots : MonoBehaviour
{
    public float timeBetweenPhotos = 3;
    private float nextPhotoTime;
    public bool takeScreenshot = false;
    public int resWidth;
    public int resHeight;
    public int scale = 1;
    public bool isTransparent;
    // using a local path here since it's less of a pain to work with
    public string localPath;
    // set up the absolute path here
    private string absolutePath => Path.Combine(Application.dataPath, localPath);
    private string lastScreenshot = "";
    private Camera myCamera;
    void Start()
    {
        myCamera = Camera.main;
    }
    void Update()
    {
        // Almost just like the code on Screenshot.OnGUI() but a little different
        // a little bit of timing code for repeated photo-taking
        if (takeScreenshot && Time.time > nextPhotoTime) {
            // make sure to move this forward every time
            nextPhotoTime = Time.time + timeBetweenPhotos;
            int resWidthN = resWidth * scale;
            int resHeightN = resHeight * scale;
            RenderTexture rt = new RenderTexture(resWidthN, resHeightN, 24);
            myCamera.targetTexture = rt;
            TextureFormat tFormat;
            if (isTransparent)
                tFormat = TextureFormat.ARGB32;
            else
                tFormat = TextureFormat.RGB24;
            Texture2D screenShot = new Texture2D(resWidthN, resHeightN, tFormat, false);
            myCamera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidthN, resHeightN), 0, 0);
            myCamera.targetTexture = null;
            RenderTexture.active = null;
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidthN, resHeightN);
            File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            // we don't open the photo right away since thats a pain,
            // and we aren't going to turn off "takeScreenshot"
        }
    }
    public string ScreenShotName(int width, int height) {
        string strPath = "";
        strPath = string.Format("{0}/screen_{1}x{2}_{3}.png",
                             absolutePath,
                             width, height,
                                       System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        lastScreenshot = strPath;
        return strPath;
    }
}
Set up the component how you'd like and use the `takeScreenshot` checkbox with the game running to turn this on and off.
