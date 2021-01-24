    using UnityEngine;
    
    public class CameraFollow : MonoBehaviour
    {
        Vector3 LastCameraPosition = Vector3.positiveInfinity;
    
        public Transform target;
    
        public bool X, Y, Z;
    
        public float XOffset, YOffset, ZOffset;
    
        void Update()
        {
    
            if (target.position.y < LastCameraPosition.y)
            {
                LastCameraPosition = target.position;
                Y = true;
            }
            else
            {
                Y = false;
            }
    
            transform.position = new Vector3(
           (X ? target.position.x + XOffset : transform.position.x),
           (Y ? target.position.y + YOffset : transform.position.y),
           (Z ? target.position.z + ZOffset : transform.position.z));
        }
    }
