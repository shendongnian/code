        public class CheckInternets : MonoBehaviour
        {
            private string url = "some photo on my google drive";
            private wwww;
        
            public static bool InternetON = false;
            public static bool IsFinished = false;
        
            // Start is called before the first frame update
            private void Start()
            {
                StartCoroutine(CheckConnection());
            }
        
            public IEnumerator CheckConnection()
            {
                IsFinished = false;
        
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
        
                IsFinished = true;
            }
        }
    
