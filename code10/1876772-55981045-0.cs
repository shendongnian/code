    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameobject.tag)
            case "tag_here"
               isDead = true;
               rb2d.velocity = Vector2.zero;
               GameController.Instance.Die();
               break;
           case "tag_here2"
               isDead = true;
               rb2d.velocity = Vector2.zero;
               GameController.Instance.Die();
               break;
           case "tag_here3"
               isDead = true;
               rb2d.velocity = Vector2.zero;
               GameController.Instance.Die();
               break;
           //Copy paste as long as you need more
        }
