    using System.Collections.Generic;
    using UnityEngine;
    
    public class CollisionDetection : MonoBehaviour
    {
        private HashSet<int> collidingGameObjects = new HashSet<int>();
    
        private void OnCollisionEnter( Collision collision )
        {
            collidingGameObjects.Add( collision.gameObject.GetInstanceID() );
        }
    
        private void OnCollisionExit( Collision collision )
        {
            collidingGameObjects.Remove( collision.gameObject.GetInstanceID() );
        }
    
        // Clear the list in OnDisable because `OnCollisionExit` is not called
        // when object is disabled
        private void OnDisable()
        {
            collidingGameObjects.Clear();
        }
    
        private void Update()
        {
            if( collidingGameObjects.Count == 0 )
            {
                Debug.Log( "I am not colliding with anything" );
            }
        }
    }
