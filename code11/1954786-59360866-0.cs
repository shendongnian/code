    private int Counter = 0; // define Counter
    public float energyLevel = 0;
    
    public IEnumerator DoIncrement()
     {
         WaitForSeconds waiter = new WaitForSeconds(1f);
         while (Counter < 5) 
         {
             yield return waiter;
             Counter++;
             Debug.Log("Counter = " + Counter);
         }
     }
