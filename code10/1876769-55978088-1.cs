    private bool enemy, ground;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = true;
        }
    
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    
        if(enemy && ground)
        {
            Debug.Log("Enemy and Ground collision");
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy= false;
        }
    
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = false;
        }
    }
