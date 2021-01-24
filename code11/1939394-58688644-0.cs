    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyUp("space"))
            {
                print("Space key was released");
            }
        }
    }
