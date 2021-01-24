    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class ConstantMoveByX : MonoBehaviour
    {
        [SerializeField]
        private float constantSpeed = 10.0f;
        [SerializeField]
        private float jumpForce = 25.0f;
        [SerializeField]
        private float gravity = 9.8f;
        private CharacterController characterController;
        private Vector3 moveDirection = Vector3.zero;
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }
        private void Update()
        {
            if (characterController.isGrounded)
            {
                moveDirection = Vector3.right * constantSpeed;
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * constantSpeed;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpForce;
                }
            }
        
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
