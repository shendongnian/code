public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform originalTransform;
    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Ellen"))
        {
            Invoke("DropPlatform", 0.5f);
            respawn(gameObject, 2f);
        }
    }
    private void InvokeRepeating(string v1, float v2)
    {
        throw new NotImplementedException();
    }
    private void respawn(GameObject gameObject, float v)
    {
        gameobject.transform.position = originalTransform.position
        rb.isKinematic = true;
    }
    private void DropPlatform()
    {
        originalTransform = gameobject.transform;
        rb.isKinematic = false;
    }
