    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class BoxFalling : MonoBehaviour
    {
        public GameMain gameMain;
    
        void Update()
        {
            // Is still falling allowed?
            // now you can got it
            if (GameMain.Instance.getFalling()){
                transform.Translate(Vector3.down);
            }
        }
    }
