    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Networking;
    
    namespace MyCompany.MyGame {
        public class User {
            public string login;
        }
    
        public class MyService {
            public IEnumerator GetUser (Action<User> callback) {
                using (UnityWebRequest webRequest = UnityWebRequest.Get ("https://api.github.com/users/octocat")) {
                    yield return webRequest.SendWebRequest ();
                    callback (JsonUtility.FromJson<User> (webRequest.downloadHandler.text));
                }
            }
        }
    }
