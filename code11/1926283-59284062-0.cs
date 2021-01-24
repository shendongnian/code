    using UnityEngine.Experimental.Rendering.Universal;
    using UnityEngine;
    
    public class Light2DController : MonoBehaviour {
        void Awake() {
            //assuming You have Light2D component in the same object that has this script
            Light2D light = transform.GetComponent<Light2D>();
        }
    }
