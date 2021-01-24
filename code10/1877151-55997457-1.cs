    public class MyControls{
      public List<string> controls;
    }
    
    public class CustomControls : MonoBehaviour
    {
        private MyControls myControls;
    
        void Start()
        {
            LoadJson();
            for (int i = 0; i < myControls.controls.Count; i++)
            {
                Debug.Log(myControls.controls[i]);//No need to use ToString() here, it`s already a string
            }
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
    
