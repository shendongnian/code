    using System.Collections; 
    using System.Collections.Generic; 
    using UnityEngine; 
    using UnityStandardAssets.CrossPlatformInput;
    
    
    
    public class TestScript : MonoBehaviour 
    {
    
    	// Use this for initialization 	
       void Start () 
       {
    		 	
       } 	 	
    
        // Update is called once per frame 	
       void Update ()
       {
    
            float angle =  CrossPlatformInputManager.GetAxis("Horizontal");
            float torque =  CrossPlatformInputManager.GetAxis("Vertical");
    
    
            print("Angle : " + angle + "  ,  Torque : " + torque);
    
        } 
    
    }
