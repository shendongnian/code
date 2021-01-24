    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityStandardAssets.CrossPlatformInput;
    
    public class PlayerControl : MonoBehaviour
    {
        // We gonna move by WASD keys
    
        [Header("Speed settings")]
        [SerializeField]
        float movSpeedX = 0.8f;
        [SerializeField]
        float movSpeedY = 2.4f;
    
        void Update()
        {
            if(Input.GetKeyUp(KeyCode.W)){
                transform.Translate(Vector2.up * movSpeedY);
            }
            if(Input.GetKeyUp(KeyCode.S)){
                transform.Translate(Vector2.down * movSpeedY);
            }
            if(Input.GetKeyUp(KeyCode.D)){
                transform.Translate(Vector2.Left * movSpeedX);
            }
            if(Input.GetKeyUp(KeyCode.A)){
                transform.Translate(Vector2.right * movSpeedX);
            }
        }
    }
