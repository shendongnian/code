    public class DataLoader : MonoBehaviour
    {
        string jsonDataString;
        
        static public string originalJsonSite = "http://(web service name)/API/testnot.php";
        
        public Text tituloNot;
        public Text textoNot;
        
        IEnumerator Start ()
        {
            WWW readingsite = new WWW (originalJsonSite);
            yield return readingsite;
            if (string.IsNullOrEmpty (readingsite.error))
            {
                jsonDataString = readingsite.text;
            }
            JSONNode jsonNode = SimpleJSON.JSON.Parse(jsonDataString);
            JSONArray array = jsonNode.AsArray;
            tituloNot.text = array[0]["titulo"].ToString();
            textoNot.text = array[0]["texto"].ToString();
        }
    }
