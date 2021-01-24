    public class ScreenShotManager : MonoBehaviour {
    const string FilePath = @"C:\Users\UserName\Desktop\ScreenShots";
    public void CaptureScreenShot() {
        ScreenCapture.CaptureScreenshot(FilePath);
    }
     
    void Update(){
        if(Input.GetKeyDown(Keycode.C))
            CaptureScreenShot();
    }
