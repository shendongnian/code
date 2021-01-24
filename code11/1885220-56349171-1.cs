    #if UNITY_IOS
        using Unity.Notifications.iOS;
    #elseif UNITY_ANDROID
        using Unity.Notifications.Android;
    #endif
    ...
    #if UNITY_IOS
        <Code for IOS>
    #elseif UNITY_ANDROID
        <Code for Android>
    #endif
