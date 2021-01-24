    using UnityEngine;
    public class DestroyableObject : MonoBehaviour
    {
        public bool Destroyed { get;  set; }
        public Vector3 Position { get; set; }
        private void OnDestroy()
        {
            Position = transform.position;
            Destroyed = true;
        }
    }
