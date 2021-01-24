    private rotcount = 1;
    private void OnMouseDown()
    {
        if (rotcount == 1)
        {
            for (int i = 0; i < objectsToRotate.Length; i++)
            {
               StartCoroutine(Rotates(i));
            }
        }
    }
    private IEnumerator Rotates(int i)
    {
        if (i == 0)
        {
            yield return null; // no need to create an object that does nothing
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(0, 2f));
        }
        Transform objectToRotate = objectsToRotate[i].transform
        Quaternion startRot = objectToRotate.rotation;
        float t = 0.0f;
        lastFwd = objectToRotate.transform.forward;
        rotcount++;
        while (t < duration)
        {
            // Rotation code
            yield return null;
        }
        objectToRotate.rotation = startRot;
        desiredAngle = false;
        if (rotcount == 4){ rotcount = 1; }
    }
