    void FixedUpdate()
    {
        StartCoroutine(WaitForFixedUpdateCoroutine());
    }
    IEnumerator WaitForFixedUpdateCoroutine()
    {
        yield return WaitForFixedUpdate();
    
        if(!isCollision)
        {
            //blah blah blah
        }
    }
