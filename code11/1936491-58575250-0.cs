    [SerializeField]
    private Transform HuamantlPlace;
    private float deltaX, deltaY;
    public static bool locked;
    
    //use this for initialiozation
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                 
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - HuamantlPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - HuamantlPlace.position.y) <= 0.5f)
                    {
                        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        transform.position = new Vector2(HuamantlPlace.position.x, HuamantlPlace.position.y);
                        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                        locked = true;
                    }
                    else
                    {
                        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    }
                    break;
            }
        }
    }
}
