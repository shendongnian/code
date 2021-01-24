    using UnityEngine;
    using UnityEngine.Android;
    
    ...
    
    #if UNITY_2018_3_OR_NEWER && UNITY_ANDROID
    
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera)) {
            Permission.RequestUserPermission(Permission.Camera);
        }
