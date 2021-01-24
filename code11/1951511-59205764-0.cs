public float speed = 50f;
private Rigidbody rb;
void Awake() {
    rb = GetComponent<Rigidbody>();
}
private void Update() {
    if (Input.GetKey(KeyCode.A))
        rb.AddForce(Vector3.left * speed);
    if (Input.GetKey(KeyCode.D))
        rb.AddForce(Vector3.right * speed);
    if (Input.GetKey(KeyCode.W))
        rb.AddForce(Vector3.forward * speed);
    if (Input.GetKey(KeyCode.S))
        rb.AddForce(Vector3.back * speed);
}
----------
Finally for those who are more familiar with Unity, I encourage you to use the  [New Input System](https://www.youtube.com/watch?v=Gz0YcjXBJ3U).
