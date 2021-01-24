    public class colorchange : MonoBehaviour
    {
        public int color;        
        public float delaySeconds = 1f;
        IEnumerator changeColorCoroutine;
        SpriteRenderer mySprite;
        public bool doChangeColor;
        void Start()
        {
            // cache result of expensive GetComponent call
            mySprite = GetComponent<SpriteRenderer>();
            // initialize flag
            doChangeColor = true;
            // create coroutine
            changeColorCoroutine = ChangeColor();
 
            // start coroutine
            StartCoroutine(changeColorCoroutine);
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // toggle doChangeColor
                doChangeColor = !doChangeColor;
            }
        }
        IEnumerator ChangeColor()
        {
            WaitUntil waitForFlag = new WaitUntil( () => doChangeColor);
            while (true)
            {
                yield return waitForFlag;
                Debug.Log("Hello");
                color = Random.Range(1, 5);
                // switch for neater code
                switch (color)
                {
                case 2:
                    mySprite.color = Color.blue;
                    break;
                case 3:
                    mySprite.color = Color.red;
                    break;
                case 4:
                    mySprite.color = Color.yellow;
                    break;
                }
                yield return new WaitForSeconds(delaySeconds);
            }
        }
    }
