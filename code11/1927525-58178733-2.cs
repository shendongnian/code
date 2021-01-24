    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TestScript : MonoBehaviour
    {
        Vector3 upperLeft;
        Vector3 downRight;
    
        GameObject prefab;
    
        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(0, 0, -3);
            upperLeft = new Vector3(-1, -1);
            downRight = new Vector3(1, 1);
    
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
    
    
        public void SpawnEachEnemy(GameObject Enemy)
        {
            Vector3 futurePosition;
            Collider2D[] collider2Ds;
            do { 
                futurePosition = new Vector2(
                    UnityEngine.Random.Range(
                        upperLeft.x,
                        downRight.x),
                                                    
                    UnityEngine.Random.Range(
                        upperLeft.y, 
                        downRight.y));
                collider2Ds = Physics2D.OverlapCircleAll(futurePosition, 0.2f)
            } 
            while (collider2Ds.Length > 0)
    
            GameObject b = Instantiate(Enemy) as GameObject;
            b.transform.position = futurePosition;
            b.transform.parent = this.transform;
        }
    }
