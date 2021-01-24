    using UnityEngine;
    using System.Collections;
     
    public class Health : MonoBehaviour
    {
         private Force [] scripts = null;
         [SerializeField] private int health = 5;
     
         private void Start()
         {
             this.scripts = this.gameObject.GetComponents<Force>();
         }
     
         private void Update()
         {
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 for (int i = 0; i < this.scripts.Length; i++)
                 {
                     if(this.scripts[i].ReportForce())
                     {
                         this.health += 5;
                     }
                 }                              
             }
         }
    }
