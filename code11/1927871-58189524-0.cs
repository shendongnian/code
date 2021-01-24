public class colorchange : MonoBehaviour
{
    public int color;
    public bool stop = true;
    public float delay;
    private float timer;
    void Start()
    {
        timer = delay;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = delay;
            Debug.Log("Hello");
            color = Random.Range(1, 5);
            if (color == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (color == 3)
            { 
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (color == 4)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }
}
