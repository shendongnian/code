     if (onGround)
          {
              if (Input.GetButtonDown("Jump"))
              {
                rb.velocity = new Vector3(0f, 50f, 0f);
                onGround = false;
                coinCollected = false;
              }
          }
      }
