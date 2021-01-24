    public class Bullet : MonoBehaviour
    {
      public float speed = 20f;
      private Vector2 direction;
    void Start()
    {
        direction= Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = direction.normalized;
    }
    void Update()
    {
        transform.position+=  = direction * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Equals("Player") && !collision.name.Equals("Bullet(Clone)"))
        {
            Destroy(gameObject);
        }
    }
    }
