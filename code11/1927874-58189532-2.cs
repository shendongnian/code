    public class colorchange : MonoBehaviour
    {
        public int color;        
        public float delaySeconds = 1f;
        IEnumerator changeColorCoroutine;
        public bool doChangeColor;
        void Start()
        {
            doChangeColor = true;
            changeColorCoroutine = ChangeColor();
 
            StartCoroutine(changeColorCoroutine);
        }
        void OnMouseDown()
        {
            // toggle doChangeColor
            doChangeColor = !doChangeColor;
        }
        IEnumerator ChangeColor()
        {
            while (true)
            {
                yield return new WaitUntil( () => doChangeColor);
                Debug.Log("Hello");
                color = Random.Range(1, 5);
                if (color == 2)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else if (color == 3)
                { 
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (color == 4)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                yield return new WaitForSeconds(delaySeconds);
            }
        }
    }
