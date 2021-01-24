        public class CheckInternets : MonoBehaviour
        {
            private static string url = "some photo on my google drive";
            private static string wwww;
        
            public static bool InternetON = false; 
        
            public static IEnumerator CheckConnection()
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
            }
        }
    
