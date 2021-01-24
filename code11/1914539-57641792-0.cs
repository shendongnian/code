    using UnityEngine;
    
    public class SaveDataHere : MonoBehaviour {
    
        public string myData;
    
        public static string staticData = "Static data is still here";
    
    	// Use this for initialization
    	void Start () {
            DontDestroyOnLoad(this);
    
            myData = "I didn't get destroyed haha";
            
    	}
    }
