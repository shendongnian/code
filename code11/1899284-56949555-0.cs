    void Update()
    {
        if(Input.touches > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            float width_fraction = pos.x / (float)Screen.width;
            // only run this, if finger is on the right half (50%)
            if(width_fraction > 0.5)
            {
                this.transform.Rotate(0, Time.deltatime * 30f, 0); // rotate 30 Deg per second
            }
        }
    }
