    Using System;
    IEnumerator WaitToLoad(Action myAction)
        {
            float currentWaitTime = 0;
            while (currentWaitTime < defaultWaitTime)
            {
                currentWaitTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            StartCoroutine(myAction());
        }
