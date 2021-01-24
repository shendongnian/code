    using System.IO;
    using UnityEngine;
    using System.Collections.Generic;
    
    public class MyControls{
        public List<string> controls;
    }
    
    public class CustomControls : MonoBehaviour
    {
        private MyControls myControls;
    
        void Start()
        {
            SaveJson();
            LoadJson();
            for (int i = 0; i < myControls.controls.Count; i++)
            {
                Debug.Log(myControls.controls[i]);//No need to use ToString() here, it`s already a string
            }
        }
    
        public void SaveJson()
        {
            MyControls testControls = new MyControls() //Creates a new instance of MyControls
            {
                controls = new List<string>(2) {"a", "b"} //Your list of strings should go here.
            };
    
            File.WriteAllText("CustomControls.json", JsonUtility.ToJson(testControls)); 
    
        }
    
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("CustomControls.json"))
            {
                string json = r.ReadToEnd();
                myControls = JsonUtility.FromJson<MyControls>(json);
            }
        }
    }
    
