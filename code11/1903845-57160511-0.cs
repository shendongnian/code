    private void SetSprite(GameObject go, Bubble.Type type)
    {
        go.transform.localScale = new Vector3(25f, 25f, 1.0f);
    
        SpriteRenderer render = go.GetComponent<SpriteRenderer>();
        render.sprite = getBubbleSprite (type);
    
        Bubble bubble = go.GetComponent<Bubble>();
        bubble.type = type;
    }
