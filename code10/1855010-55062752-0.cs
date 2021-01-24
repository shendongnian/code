    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.tag == "PlayerBullet")
       {
          this.score += 100;
          Physics2D.IgnoreCollision(col, GetComponent<Collider2D>())
       }
    }
