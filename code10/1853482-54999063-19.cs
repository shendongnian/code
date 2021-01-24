        public class CheckInternets : MonoBehaviour
        {
            private string url = "some photo on my google drive";
            private string wwww;
        
            // now you wouldn't need this anymore and could make it 
            // a local variable in the CheckConnectionRoutine
            public static bool InternetON = false;
        
            public void CheckConnection(Action<bool> callback)
            {
                StartCoroutine(CheckConnectionRoutine(callback));
            }
        
            private IEnumerator CheckConnectionRoutine(Action<bool> callback)
            {
                var www = new WWW(url);
        
                yield return www;
        
                if (www.isDone && www.bytesDownloaded > 0)
                {
                    InternetON = true;
                    Debug.Log("MAIN Script Check :: Online! :)");
                }
        
                if (www.isDone && www.bytesDownloaded == 0)
                {
                    InternetON = false;
                    Debug.LogWarning("MAIN Script Check :: Offline! :(");
                }
        
                callback?.Invoke(InternetON);
            }
        }
