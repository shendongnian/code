    public class Player : MonoBehaviour
    {
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rocks")
        {
            source.Play();
            PlayExplosionAnimation();
            gameObject.SetActive("false");
            Destroy(gameObject, 1f);
        }
    }
}
