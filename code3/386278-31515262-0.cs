    using UnityEngine;
    using System.Collections;
    
    public class ExtensionVector3 : MonoBehaviour {
    
    	public static float CalculateEulerSafeX(float x){
    		if( x > -90 && x <= 90 ){
    			return x;
    		}
    
    		if( x > 0 ){
    			x -= 180;
    		} else {
    			x += 180;
    		}
    		return x;
    	}
    
    	public static Vector3 EulerSafeX(Vector3 eulerAngles){
    		eulerAngles.x = CalculateEulerSafeX(eulerAngles.x);
    		return eulerAngles;
    	}
    }
