    public class Search : MonoBehaviour
    {
        public void SearchEnter()
        {
            StartCoroutine(LoadImage(name.ToLower()))
        }
    
        IEnumerator LoadImage(string ImageName)
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("file:///C:/MyFilePath" + ImageName + ".jpg"))
            {
                yield return uwr.SendWebRequest();
    
                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log(uwr.error);
                }
                else
                {
                    // Get downloaded texture
                    var texture = DownloadHandlerTexture.GetContent(uwr);
    
                    //TODO now use it
                    ...
                }
            }
        }
    }
