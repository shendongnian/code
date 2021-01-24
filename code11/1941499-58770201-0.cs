    public class MyBehavior : MonoBehaviour 
    {
        public void NextButton()
        {
            StartCoroutine(Upload());
        }
    
        IEnumerator Upload()
        {
            byte[] myData = System.Text.Encoding.UTF8.GetBytes("{\"messages\":{\"message\":\"" + HighlightedObject.GetComponent<OBClick>().name + "\"}}");
            using (UnityWebRequest www = UnityWebRequest.Put(YOUR_URL, myData))
            {
                yield return www.Send();
    
                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Upload complete!");
                }
            }
        }
    }
