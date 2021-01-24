public class InvisibleBlock : MonoBehaviour
{
    public SpriteRenderer rendObject;
    private void Start()
    {
        if (gameObject.tag == "Invisible")
        {
            rendObject.enabled = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rendObject.enabled = true;
        }
    }
}
Separate script, sprite is attached in inspector, same results.
