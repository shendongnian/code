     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
    
     public class DestroyOnClick : MonoBehaviour
     {
         public float lifeTime = 10f;
    
    
         void Update()
         {
             if (lifeTime > 0)
             {
                 lifeTime -= Time.deltaTime;
                 if(lifeTime <= 0)
                 {
                     Destruction();
                 }
             }
    
    
         }
         //write here , it only work in this gameobject
         void OnMouseDown() { Destruction(); }
    
         void Destruction()
         {
             Destroy(this.gameObject);
         }
     }
