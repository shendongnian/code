    public class IFScriptPlayerName : MonoBehaviour
    
    {
    
        [Serializable]
        public class MyClass
        {
            //public int level;
            //public float timeElapsed;
            //public string playerName;
            //public InputField PlayerName;
            //public InputField CharName;
            //public InputField CharRank;
    
       [SerializeField]
        public string playerName {  get; set; }
    
        }
    
        MyClass myObject = new MyClass();
    
        public string playerName;
    
    
        public string SaveToString()
        {
            return JsonUtility.ToJson(myObject);
        }
    
        void Start()
        {
            var input = gameObject.GetComponent<InputField>();
            var se = new InputField.SubmitEvent();
            //se.AddListener(SubmitName);
            //input.onEndEdit = se;
    
            //or simply use the line below, 
            input.onEndEdit.AddListener(SubmitName);  // This also works
        }
    
        private void SubmitName(string playerName)
        {
            //Debug.Log(arg0);
        Debug.Log("Entered" + playerName);
    
        //playerName = arg0;
        Debug.Log ("Start SubmitName!" + SaveToString());
    
        StartCoroutine(Post("https://mywebsite.com/api/api2.php", SaveToString()));
        }
    
        IEnumerator Post(string url, string bodyJsonString)
        {
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
    
            yield return request.Send();
    
            Debug.Log("Status Code: " + request.responseCode);
        Debug.Log("Received: " + request.downloadHandler.text);
        Debug.Log("json string: " + SaveToString());
        }
    }
