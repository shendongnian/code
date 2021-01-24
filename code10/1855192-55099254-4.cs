     bool isRunning = false;
     //Make sure this variable is true when triggered and false when not
     bool isTrigger = false;
     float rotationAmount = 0.3f;
     public IEnumerator SlowSpin2()
     {
        isRunning = true;
        //This will rotate the object continuously until isTriggered is false
        while (isTriggered)
        {
            Debug.Log("Rotating");
            transform.Rotate(new Vector3(0, -rotationAmount, 0));            
            yield return null;
           
        }
        Debug.Log(Time.time);
        isRunning = false;
     }
