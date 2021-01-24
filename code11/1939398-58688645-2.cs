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
    
        float movX;
        float movY;
    
        Rigidbody2D rb;
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            if(Input.GetKeyUp(KeyCode.W)){
                movY += movSpeedY;
            }
            if(Input.GetKeyUp(KeyCode.S)){
                movY -= movSpeedY;
            }
            if(Input.GetKeyUp(KeyCode.D)){
                movX += movSpeedX;
            }
            if(Input.GetKeyUp(KeyCode.A)){
                movX -= movSpeedX;
            }
    
            rb.velocity = new Vector2(movX, movY);
        }
    }
