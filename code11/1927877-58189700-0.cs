csharp
public class colorchange : MonoBehaviour
{
    public int color;
    public bool stop = true;
    private SpriteRenderer _mySpriteRenderer;
    private float _timeBetweenChanges = 0.5F;
    private float _lastChange = 0f;
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Time.time - _lastChange >= _timeBetweenChanges)
        {
            _lastChange = Time.time;
            color = Random.Range(1, 5);
            if (color == 2)
            {
                _mySpriteRenderer.color = Color.blue;
            }
            if (color == 3)
            { 
                _mySpriteRenderer.color = Color.red;
            }
            if (color == 4)
            {
                _mySpriteRenderer.color = Color.yellow;
            }
        }
    }
}
**Note :** you can cache your component SpriteRenderer to avoid the `GetComponent` call each time. [See here](https://forum.unity.com/threads/best-practice-for-how-often-to-use-getcomponent.517039/)
**2**
csharp
public class colorchange : MonoBehaviour
{
    public int color;
    public bool stop = true;
    private SpriteRenderer _mySpriteRenderer;
    private float _timeBetweenChanges = 0.5F;
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("ChangeColor", 0F, _timeBetweenChanges);
    }
    void Update()
    {
        // You don't need Update here, you can safly remove it unless you need it for anything else
    }
    void ChangeColor()
    {
        color = Random.Range(1, 5);
        if (color == 2)
        {
            _mySpriteRenderer.color = Color.blue;
        }
        if (color == 3)
        { 
            _mySpriteRenderer.color = Color.red;
        }
        if (color == 4)
        {
            _mySpriteRenderer.color = Color.yellow;
        }
    }
}
# Random #
You can use an RNG to dertermine if you want to change color this frame or not. It implies you can't define how many times per `sec / min / in general` you will change the color.
csharp
public class colorchange : MonoBehaviour
{
    public int color;
    public bool stop = true;
    private SpriteRenderer _mySpriteRenderer;
    private float _randomChance = 0.2F;
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Random.Range(0F, 1F) < _randomChance)
        {
            color = Random.Range(1, 5);
            if (color == 2)
            {
                _mySpriteRenderer.color = Color.blue;
            }
            if (color == 3)
            { 
                _mySpriteRenderer.color = Color.red;
            }
            if (color == 4)
            {
                _mySpriteRenderer.color = Color.yellow;
            }
        }
    }
}
Here you have 20
