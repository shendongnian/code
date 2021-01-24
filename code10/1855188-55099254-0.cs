     bool isRunning = false;
     float flipDuration = 2.0f
     public IEnumerator SlowSpin2()
     {
        float t = 0;
        while (t < flipDuration)
        {
            isRunning = true;
            t += Time.deltaTime;
            dummyrotate.transform.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 90, 0), t / flipDuration);
            yield return null;
            isRunning = false;
        }
    }
