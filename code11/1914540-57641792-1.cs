    using UnityEngine;
    public class InNewScene : MonoBehaviour {
    
    	// Use this for initialization
    	void Start () {
    		var saveData = FindObjectOfType<SaveDataHere>();
            Debug.Log("instance data is " + saveData.myData);
            Debug.Log("static data is " + SaveDataHere.staticData);
    	}
    }
