    private float timer = 5;
    private void Update()
    {
        if (randomSpin == true)
        {
             timer -= Time.deltaTime;
             if(timer <= 0)
             {
                objectToSpin.transform.Rotate(Random.Range(spinX, 360), Random.Range(spinY, 360), Random.Range(spinZ, 360));
                timer = 5;
            }
        }
        else
        {
            objectToSpin.transform.Rotate(spinX, spinY, spinZ);
        }
    }
