    namespace VirtualOS {
    
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;
    
    public class Plug : MonoBehaviour
    {
        // A plug that can be inserted into sockets.
    
        [SerializeField] SocketPlugShape shape = SocketPlugShape.None;
        [SerializeField] float plugRadius = 0.05f;
        [SerializeField] AudioSource unfittingSocketSound = null;
    
        public void OnDrag()
        {
            Socket socket = GetComponentInParent<Socket>();
            if (socket)
            {
                socket.RemovePlug();
            }
        }
        
        public bool OnDrop()
        {
            return LookForFittingSocketsNearby();
        }
        
        public void Unplug()
        {
            Socket socket = GetComponentInParent<Socket>();
            if (socket)
            {
                socket.RemovePlug();
            }
        }
        
        bool LookForFittingSocketsNearby()
        {
            bool success = false;
            Collider[] colliders = Physics.OverlapSphere(transform.position, plugRadius);
            colliders = colliders.OrderBy(
                x => Vector3.Distance(transform.position, x.transform.position)
            ).ToArray();
    
            bool unfittingSocketFound = false;        
            foreach (Collider collider in colliders)
            {
                Transform parent = collider.transform.parent;
                if (parent != null)
                {
                    Socket socket = parent.GetComponent<Socket>();
                    if (socket != null)
                    {
                        success = socket.TryInsertPlug(this);
                        if (success)
                        {
                            break;
                        }
                        else
                        {
                            unfittingSocketFound = true;
                        }
                    }
                }
            }
            
            if (unfittingSocketFound && !success)
            {
                HandleUnfittingSocketSound();
            }
            
            return success;
        }
    
        void HandleUnfittingSocketSound()
        {
            unfittingSocketSound.Play();
            Handable handable = GetComponentInParent<Handable>();
            if (handable != null)
            {
                handable.InvertVelocity();
            }
        }
    
        public SocketPlugShape GetShape()
        {
            return shape;
        }
    
    }
    
    }
