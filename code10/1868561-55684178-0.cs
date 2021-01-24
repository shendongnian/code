C#
public bool IsTestLab()
{
    using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
        var context = actClass.GetStatic<AndroidJavaObject>("currentActivity");
        var systemGlobal = new AndroidJavaClass("android.provider.Settings$System");
        var testLab = systemGlobal.CallStatic<string>("getString", context.Call<AndroidJavaObject>("getContentResolver"), "firebase.test.lab");
        return testLab == "true"
    }
}
