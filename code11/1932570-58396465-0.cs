    #if UNITY_WSA
    using Kinemic.Gesture;
    #endif
    using UnityEngine
    
    public class SomeClass : MonoBehaviour
    {
        public void SomeFunction
        {
            #if UNITY_WSA
            // call some code in the Kinemic.Gesture library.
            #endif
        }
    
    }
