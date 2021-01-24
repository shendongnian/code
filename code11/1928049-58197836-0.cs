    public class colorchange : MonoBehaviour
    {
        public int color;
    
        private SpriteRenderer _mySpriteRenderer;
        private float _timeBetweenChanges = 1f;
        private Coroutine _colorRoutine;
    
        void Start()
        {
            _mySpriteRenderer = GetComponent<SpriteRenderer>();
            _colorRoutine = StartCoroutine(ChangeColor());
        }
    
        IEnumerator ChangeColor()
        {
            while (true)
            {
                color = Random.Range(1, 5);
                if (color == 2)
                {
                    _mySpriteRenderer.color = Color.blue;
                }
                else if (color == 3)
                {
                    _mySpriteRenderer.color = Color.red;
                }
                else if (color == 4)
                {
                    _mySpriteRenderer.color = Color.yellow;
                }
                yield return new WaitForSeconds(_timeBetweenChanges);
            }
        }
    
        private void OnMouseDown()
        {
            StopCoroutine(_colorRoutine );
        }
    }
