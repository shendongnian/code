    void OnTriggerEnter2D(Collider2D col)
    {
        // You can use gameObject.tag to determine what type of object we're colliding with
        if(col.gameObject.tag == "LongGrass"){
            speed = .8f;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "LongGrass"){
            speed = 1f;
        }
    }
