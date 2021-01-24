    using System.IO;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Networking;
    
    public static class Example
    {
        // InitializeOnLoadMethod causes this method to be called when the editor is opened
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            #region Required Part
            // register callback
            // The editor will only close if OnQuitEditor returns true
            EditorApplication.wantsToQuit += OnQuitEditor;
    
            // I'll just do a random Get Request but you can do any request here
            var request = UnityWebRequest.Get("https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Example.svg/2000px-Example.svg.png");
    
            request.SendWebRequest();
    
            while (!request.isDone && !request.isHttpError && !request.isNetworkError)
            {
                // just wait
            } 
            if(request.isHttpError || request.isNetworkError || !string.IsNullOrWhiteSpace(request.error))
            {
                Debug.LogError("Couldn't finish opening request!");
                return;
            }    
            #endregion Required Part
            #region DEMO Part
            // Just to show here that it worked create a file called "Open"
            var filePath = Path.Combine(Application.streamingAssetsPath, "open.txt");
            if (!Directory.Exists(Application.streamingAssetsPath)) Directory.CreateDirectory(Application.streamingAssetsPath);
    
            using (var file = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.Write("Hello!");
                }
            }
            #endregion DEMO Part
        }
    
        /// <summary>
        /// Hinders the Editor to close if the request failed
        /// </summary>
        /// <returns></returns>
        private static bool OnQuitEditor()
        {
            #region Required Part
            // I'll just do a random Get Request but you can do any request here
            var request = UnityWebRequest.Get("https://image.shutterstock.com/image-vector/example-red-square-grunge-stamp-260nw-327662909.jpg");
    
            request.SendWebRequest();
    
            while (!request.isDone && !request.isHttpError && !request.isNetworkError)
            {
                // just wait
            }
            if(request.isHttpError || request.isNetworkError || !string.IsNullOrWhiteSpace(request.error))
            {
                Debug.LogError("Couldn't finish closing request!");
                return false;
            }    
            #endregion Required Part
    
            #region DEMO Part
            // Just to show here that it worked delete the Open file and create a closed file
            if (!Directory.Exists(Application.streamingAssetsPath)) Directory.CreateDirectory(Application.streamingAssetsPath);
    
            var filePath = Path.Combine(Application.streamingAssetsPath, "open.txt");
            if(File.Exists(filePath)) File.Delete(filePath);
    
            filePath = Path.Combine(Application.streamingAssetsPath, "close.txt");
    
            using (var file = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.Write("World!");
                }
            }
            #endregion DEMO Part
    
            return string.IsNullOrEmpty(request.error);
        }
    }
