     using UnityEngine;  
     using System.Collections;    
    public class OrbitPlayer : MonoBehaviour {
     
         public float turnSpeed = 5.0f;
         public GameObject player;
         private Transform playerTransform;     
         private Vector3 offset;
         private float yOffset = 10.0f;
         private float zOffset = 10.0f;
     
         void Start () {
             playerTransform = player.transform;
             offset = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, playerTransform.position.z + zOffset);
         }
     
         void LateUpdate()
         {
             offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
             transform.position = playerTransform.position + offset; 
             transform.LookAt(playerTransform.position);
         }  
    }
