    using UnityEngine;
    
    public class Example : MonoBehaviour
    {
        // convert 1 radian to degrees
    
        float rad = 10.0f;
    
        void Start()
        {
            float deg = rad * Mathf.Rad2Deg;
            Debug.Log(rad + " radians are equal to " + deg + " degrees.");
        }
    }
