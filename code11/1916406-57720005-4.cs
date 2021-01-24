    IEnumerator Rotate(float duration)
    {
        float t = 0.0f;
        
        List<Quaternion> startRot = new List<Quaternion>();
        for (int i = 0; i < objects.Length; i++) {
            startRot.Add(objects[i].rotation);
        }
        
        isRotating = true;
        
        while (t < duration)
        {
            yield return null;
    
            t = Mathf.Min(t+Time.deltaTime, duration);
    
            // foreach all object in one frame
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].rotation = startRot[i] * Quaternion.AngleAxis(t / duration * 360f, Vector3.up); //or transform.right if you want it to be locally based
            }
        }   
        isRotating = false;   
    }
