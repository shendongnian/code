    public class Prova2 : MonoBehaviour
    {
        Prova script1;
        public string name;
        public Text linguaitaliana=null;
        IEnumerator Start()
        {
            script1=gameObject.GetComponent<Prova>();
            name=script1.due;
    
            yield return new WaitForSeconds(1);
    
            using (var webRequest = UnityWebRequest.Get("http://arnaples.altavista.org/QueryTestoITA.phpnum=" + name))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();
    
                if (webRequest.isNetworkError || webRequest.isHttpError)
                {
                    Debug.LogFormat(this, "Download error due to {0} - {1}", webRequest.responseCode, webRequest.error);
                }
                else
                {
                    Debug.Log("Download complete: " + webRequest.downloadHandler.text, this);
                    linguaitaliana.text = webRequest.downloadHandler.text;
                }
            }
        }
    }
    
