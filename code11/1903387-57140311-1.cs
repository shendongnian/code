void OnCollisionEnter2D(Collision2D col)
     {
          if (col.gameObject.tag == "Bullet1")
          {
             lasthit = 1f;
          // I need to activate Destroyy() in Bullet1 script
             // HERE'S HOW: 
             if(col.gameObject.GetComponent<Bullet1>() != null)
               col.gameObject.GetComponent<Bullet1>().Destroyy();
          }
     }
