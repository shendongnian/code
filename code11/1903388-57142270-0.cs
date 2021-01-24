    void OnCollisionEnter2D(Collision2D col)
         {
              Bullet1 b = col.gameObject.GetComponent<Bullet1>();
              if (b == null)
              {
                  return;
              }
 
              lasthit = 1f;
              b.Destroyy();
         }
