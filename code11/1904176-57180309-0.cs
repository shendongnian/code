    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class PlayerController : MonoBehaviour
    {
    Animator anim;
    float RotateX;
    float RotateY;
    Rigidbody rb;
    public static bool GamePaused;
    public bool isGrounded;
    [SerializeField]
    [Header("Game Objects")]
    public GameObject Camera;
    public GameObject PauseMenu;
    public GameObject Player;
    [Header("Movement Settings")]
    public float DefaultSpeed = 5.0f;
    public float WalkSpeed = 5.0f;
    public float RunSpeed = 10.0f;
    public float jumpForce = 2.5f;
    public Vector3 jump;
    [Header("Rotation Settings")]
    public float RorationSpeed = 3.0f;
    public float MaxYAxis = 60.0f;
    public float MinYAxis = -48.0f;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
    }
    void Update()
    {
        Rotation();
        Movement();
        Bool();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void Rotation()
    {
        RotateX += Input.GetAxis("Mouse X") * RorationSpeed;
        RotateY += Input.GetAxis("Mouse Y") * RorationSpeed;
        RotateY = Mathf.Clamp(RotateY, MinYAxis, MaxYAxis);
        Camera.transform.localRotation = Quaternion.Euler(-RotateY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, RotateX, 0f);
    }
    void Movement()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * WalkSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * WalkSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            WalkSpeed = RunSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            WalkSpeed = DefaultSpeed;
        }
    }
    void Bool()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsWalkingForward", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("IsWalkingLeft", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsWalkingBack", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("IsWalkingRight", true);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("IsWalkingForward", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("IsWalkingLeft", true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("IsWalkingBack", true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("IsWalkingRight", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("IsWalkingForward", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("IsWalkingLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsWalkingBack", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("IsWalkingRight", false);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("IsWalkingForward", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("IsWalkingLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("IsWalkingBack", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("IsWalkingRight", false);
        }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
    }
