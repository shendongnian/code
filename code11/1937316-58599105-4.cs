    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class RoomMaker : MonoBehaviour
    {
        public float speed = 5;
        public float distance = 5;
    
        public Transform horse;
        public Transform carriage;
    
    
        void FixedUpdate() // otherwise, visual lag can make for inconsistent collision checking.
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    
            Collider2D[] cols = Physics2D.OverlapPointAll(
                    Vector3.Scale(new Vector3(1,1,0), horse.position), // background at z=0 
                    LayerMask.GetMask("background")); // ignore non background layer objects
            
    
            Collider2D backgroundCol = null;
            for (int i = 0 ; i < cols.Length ; i++) // order of increasing z value
            {
                if (cols[i].tag == "Background") // may be redundant with layer mask
                {
                    backgroundCol = cols[i];
                    break;
                }
            }
    
    
            if (backgroundCol != null)
            {
                Debug.Log("DETECTSBACKGROUND: " + backgroundCol.name);
    
            }
            else
            {
                Debug.Log("Does not detect Background");     
            }
    
        }
    }
