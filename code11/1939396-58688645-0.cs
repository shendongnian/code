    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityStandardAssets.CrossPlatformInput;
    
    public class PlayerControl : MonoBehaviour
    {
        [Header("Movement Buttons")]
        public Button ForwardButton;
        public Button BackwardsButton;
        public Button RightButton;
        public Button LeftButton;
    
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
    
            ForwardButton.onClick.AddListener(verticalMov);
            BackwardsButton.onClick.AddListener(verticalMov);
            RightButton.onClick.AddListener(horizontalMov);
            LeftButton.onClick.AddListener(horizontalMov);
        }
    
        void Update()
        {
            rb.velocity = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal") * movX,
                CrossPlatformInputManager.GetAxisRaw("Vertical") * movY);
    
            movX = 0.0f;
            movY = 0.0f;
        }
    
        void horizontalMov()
        {
            movX = movSpeedX;
        }
    
        void verticalMov()
        {
            movY = movSpeedY;
        }
    }
