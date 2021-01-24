[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
above of it in order to force it to initialize them before the scene has loaded. I am not sure why this is required, but it fixed it for me. You can see the full function below:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HapticController : Singleton<HapticController> {
    public static AndroidJavaClass unityPlayer = null;
    public static AndroidJavaObject currentActivity = null;
    public static AndroidJavaObject vibrator = null;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize(){
    #if UNITY_ANDROID && !UNITY_EDITOR
        if (Application.platform == RuntimePlatform.Android) {
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
            }
    #endif
    }
...
}
