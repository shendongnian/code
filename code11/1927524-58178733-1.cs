    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TestScript : MonoBehaviour
    {
        GameObject UpperLeft;
        GameObject DownRight;
    
        GameObject prefab;
    
        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(0, 0, -3);
            transform.rotation = Quaternion.identity;
            UpperLeft = new GameObject("UpperLeft");
            UpperLeft.transform.position = new Vector3(-1, -1);
    
            DownRight = new GameObject("DownRight");
            DownRight.transform.position = new Vector3(1, 1);
    
            prefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            DestroyImmediate(prefab.GetComponent<SphereCollider>());
            prefab.transform.localScale = 0.4f * Vector3.one;
            prefab.AddComponent<CircleCollider2D>();
    
            for (int i = 0; i < 12; i++)
            {
                SpawnEachEnemy(prefab);
            }
    
            prefab.SetActive(false);
    
        }
    
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
    
        public void SpawnEachEnemy(GameObject Enemy)
        {
            Vector3 futurePosition = new Vector2(UnityEngine.Random.Range(UpperLeft.transform.position.x, DownRight.transform.position.x),
                                        UnityEngine.Random.Range(UpperLeft.transform.position.y, DownRight.transform.position.y));
            bool correctPosition = false;
            while (!correctPosition)
            {
                Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(futurePosition, 0.2f);
                if (collider2Ds.Length > 0)
                {
                    //re-spawning to prevent overlap
                    futurePosition = new Vector2(UnityEngine.Random.Range(UpperLeft.transform.position.x, DownRight.transform.position.x),
                                        UnityEngine.Random.Range(UpperLeft.transform.position.y, DownRight.transform.position.y));
                }
                else
                {
                    correctPosition = true;
                }
    
            }
    
            GameObject b = Instantiate(Enemy) as GameObject;
            b.transform.position = futurePosition;
            b.transform.parent = this.transform;
        }
    }
