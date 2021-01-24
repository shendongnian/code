    void Start()
    {
        rect = new Rect(0f, 0f, 255, 255);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(img, rect, new Vector2(0.5f, 0.5f));
        this.GetComponent<RectTransform>().localScale = new Vector3(100, 100, 0);
        StartCoroutine(Update());
    }
    /*
     *  rect = new Rect(i, 0, 255, 255);
            this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(img, rect, new Vector2(0.5f, 0.5f));*/
    IEnumerator Update()
    {
        while (true)
        {
            if (i < 1000)
            {
                i += 255;
                if (i > 770)
                {
                    i = 0;
                }
            }
            yield return new WaitForSeconds(0.25f);
            rect = new Rect(i, 0f, 255, 255);
            this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(img, rect, new Vector2(0.5f, 0.5f));
        }
    } 
