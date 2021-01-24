            IEnumerator Rotate(float duration)
            {
               
                    
                    float t = 0.0f;
            
                    while (t < duration)
                    {
                        isRotating = true;
                        t += Time.deltaTime;
                        Quaternion startRot = objects[i].rotation;
                        // foreach all object in one frame
                        for (int i = 0; i < objects.Length; i++)
                        {
                            objects[i].rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.up); //or transform.right if you want it to be locally based
                        }
                        objects[i].rotation = startRot;
                        yield return null;
                    }
                    
            
                    isRotating = false;
                
            }
