     bool isRunning = false;
     float flipDuration = 2.0f
     public IEnumerator SlowSpin2()
     {
        
        float t = 0;
        var fromAngle = dummyrotate.transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0,90,0));
        while (t < flipDuration)
        {
            isRunning = true;
            t += Time.deltaTime;
            dummyrotate.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t/flipDuration);
            yield return null;
           
        }
        isRunning = false;
    }
