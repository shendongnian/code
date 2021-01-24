    using System.Collections;
    using UnityEngine;
    
    public class Motion : MonoBehaviour {
    
        public float speed;
    
        void Update () {
    
            if(Input.GetKey(Keycode.D)){
                Transform.Translate (Vector2.right * speed);
            }
            else if(Input.GetKey(KeyCode.A)) {
                Transform.Translate (Vector2.left * speed);
            }
            else if(Input.GetKey(KeyCode.S)) {
                Transform.Translate (Vector2.down * speed);
            }
            else if(Input.GetKey(KeyCode.W)){
                Transform.Translate (Vector2.up * speed);
            }
        }
    //dont forget to close the namespace tag(uncomment the next line if needed)
    //}
