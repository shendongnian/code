    using UnityEngine;
    using System;
    using System.IO;
    using System.Text;
    using System.Globalization;
    
    public class ReadJson : MonoBehaviour
    {
        public ContainJson classeFromJson;
        // Start is called before the first frame update
        void Start()
        {
            ReadJsonFromResources();
        }
    
        public void ReadJsonFromResources()
        {
            string json = "";
    
            using (StreamReader r = new StreamReader("./Assets/Resources/PlaceHolderJSON/data.json", Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage)))
            {
                json = r.ReadToEnd();
            }
    
            ContainJson containJson = JsonUtility.FromJson<ContainJson>(json);
    
            classeFromJson = containJson;
        }
    }
    
    [Serializable]
    public class ContainJson
    {
        public Data data;
        public int ID;
        public Caps caps;
        public string cap_key;
        public string[] roles;
        public AllCaps allcaps;
        public string filter;
    
    }
    
    
    [Serializable]
    public class Data
    {
        public string ID;
        public string user_login;
        public string user_pass;
        public string user_nicename;
        public string user_email;
        public string user_url;
        public string user_registered;
        public string user_activation_key;
        public string user_status;
        public string display_name;
    
    }
    
    [Serializable]
    public class Caps
    {
        public bool administrator;
    }
    
    
    [Serializable]
    public class AllCaps
    {
        public bool switch_themes;
        public bool edit_themes;
        public bool edit_others_user_registrations;
        public bool publish_user_registrations;
        public bool read_private_user_registrations;
        public bool delete_user_registrations;
        public bool delete_private_user_registrations;
        public bool delete_published_user_registrations;
        public bool delete_others_user_registrations;
        public bool edit_private_user_registrations;
        public bool edit_published_user_registrations;
        public bool manage_user_registration_terms;
        public bool edit_user_registration_terms;
        public bool delete_user_registration_terms;
        public bool assign_user_registration_terms;
        public bool manage_email_logs;
        public bool administrator;
    
    }
