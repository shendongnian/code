    using UnityEngine;
    public class Movement_Player : MonoBehaviour
    {
    public Rigidbody rb;
    public float default_speed;
    public float sprint_multiplier;
    private float speed;
    private void Update()
    {
        Vector3 movement = Vector3.zero
        speed = default_speed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        if (Input.GetKey(KeyCode.LeftShift))
            speed = speed * sprint_multiplier;
        else
            speed = default_speed;
        
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
