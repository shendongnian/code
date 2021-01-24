    using System.IO;
    using System.Collections.Generic;
    using UnityEngine;
    using Newtonsoft.Json;
    
    namespace AnythingOtherThanNewtonsoft.Json {
    public class CustomControls : MonoBehaviour
    {
        private List<string> controls;
    
        //public object JsonConvert { get; private set; }
    
        // Start is called before the first frame update
        void Start()
        {
            LoadJson();
            for (int i = 0; i < controls.Count; i++)
            {
                Debug.Log(controls[i].ToString());
            }
        }
    
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("CustomControls.json"))
            {
                string json = r.ReadToEnd();
                controls = JsonConvert.DeserializeObject<List<string>>(json);
            }
        }
    }
    }
