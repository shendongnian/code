    Color CreateRandomColor()
    {
        return new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 255);
    }
    void Update()
    {
        if (direction == DirecaoGameObject.Right)
        {
            Gem.transform.Translate(Vector3.right * Time.deltaTime * velocity);
            if (Gem.transform.position.x >= right.position.x)
            {
                // Use local variable here.
                var spriteRenderer =  Gem.GetComponent<SpriteRenderer>();
                spriteRenderer.color = CreateRandomColor();
                direction = SortdirecaoGameObject(direction);
            }
        }
    }
