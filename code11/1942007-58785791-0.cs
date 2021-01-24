    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class CharacterControllerInputDemo : MonoBehaviour
     {
    public float speed =3;
    public float gravity= -9;
    public float jumpHeight = 3.0f;
    public Transform groundCheck;
    public float groundDistance =  1.5f;
    public LayerMask groundMask;
    //To view in the inspector for debugging
    [SerializeField] bool isGrounded;
    // allow assignment in the editor
    [SerializeField] private CharacterController controller;
    private Vector3 velocity;
  
    void Start()
    {
        if(controller == null)
        controller = GetComponent<CharacterController>();
    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
       
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float z = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        Jump();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.E) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/=/
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
  
    void FixedUpdate()
    {
        Move();
    }
    }
