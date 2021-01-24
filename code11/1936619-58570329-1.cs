     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Pick Up"))
         {
             collObj = other.gameObject;
             collObj.SetActive(false);
             Waiter.Wait(3, () =>
             {
                 // Just to make sure by the time we're back to activate it, it still exists and wasn't destroyed.
                 if (collObj != null)
                    collObj.SetActive(true);
             });
             coin += 1;
             chubbyScore += 50;
          }
     }
