    [Serializable]
    public class Role
    {
        public string _id;
        public string name;
        public string description;
        public string type;
        public int __v;
    }
    
    [Serializable]
    public class User
    {
        public string _id;
        public bool confirmed;
        public bool blocked;
        public string email;
        public string username;
        public string provider;
        public int __v;
        public string id;
        public Role role;
    }
    
    [Serializable]
    public class Post
    {
        public string jwt;
        public User user;
   
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson (this, true);
        }
    }
