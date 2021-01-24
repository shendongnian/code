csharp
public class ScreenCapture : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            UnityEngine.ScreenCapture.CaptureScreenshot("SomeLevel");
    }
}
