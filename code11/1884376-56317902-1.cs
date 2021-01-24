    public class JSONTest : MonoBehaviour
    {
        private string jsonStr = "[{\"playerName\": \"Eduardito\", \"playerScore\": \"4\"}, {\"playerName\": \"Joel\", \"playerScore\": \"4\"}]";
        [Serializable]
        public class JSONArray<T>
        {
            public T[] Items;
        }
    
        [Serializable]
        public class User
        {
            public string playerName;
            public string playerScore;
        }
    
        void Start()
        {
            JSONArray<User> users = JsonUtility.FromJson<JSONArray<User>>("{\"Items\":" + jsonStr + "}");
            if (users.Items != null && users.Items.Length > 0)
            {
                foreach (User user in users.Items)
                {
                    Debug.Log("Deserialized user " + user.playerName);
                }
            }
            else
            {
                Debug.Log("I should never reach this code.");
            }
        }
    }
