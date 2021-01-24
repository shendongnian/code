    public class Bounce : MonoBehaviour
    {
    public Rigidbody rb;
    public float str = 0.21f;
    public float str2 = 0.15f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BouncePad")
        {
            rb.AddForce(rb.velocity * str, ForceMode.Impulse);
        }
        if (col.gameObject.tag == "BouncePad2")
        {
            rb.AddForce(rb.velocity * str2, ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
