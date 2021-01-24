    private int index = 0;
    private IEnumerator StartRotationOfObjects()
    {
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(0);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(0, 2f));
            }
            StartCoroutine(Rotates(objectsToRotate[i].transform, duration);
        }
        while(index > 0){ yield return null; }
        startRot = true;
    }
    
    private IEnumerator Rotates(Transform objectToRotate, float duration)
    {
        index++;
        while (condition)
        {
            yield return null;
        }
        index--;
    }
