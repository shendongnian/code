        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        public class SpawnAndMove : MonoBehaviour
        {
            public TargetCube TargetCube;
            public Rigidbody CubePrefab;
            public Vector3 brickPosition = new Vector3(10, 0, 0);
            Rigidbody[] objects;
            int moveCubeInstances;
            void Start()
            {
                StartCoroutine(Countdown());
            }
    
            IEnumerator Countdown()
            {
                yield return new WaitForSeconds(3f);
                objects = new Rigidbody[500];
                for (int i = 0 ; i < 500 ; i++)
                {
                    Rigidbody cubeClone = Instantiate(CubePrefab, transform.position + brickPosition, transform.rotation);
                    cubeClone.tag = "CubeInstance";
                    objects[i] = cubeClone;
                    if (i % 50 == 0)
                    {
                        yield return new WaitForFixedUpdate();
                    }
                }
    
                yield return new WaitForSeconds(3f);
                moveCubeInstances = 1;
    
                while (moveCubeInstances == 1)
                {
                    for (int i = 0 ; i < 500 ; i++)
                    {
                        objects[i].transform.position =
                                Vector3.MoveTowards(objects[i].transform.position, TargetCube.transform.position, 12f);
                    }
                    yield return new WaitForFixedUpdate();
                }
    
                print("exited while loop");
            }
        }
