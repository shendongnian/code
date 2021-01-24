    using UnityEngine;
    public class TrashCounter : MonoBehaviour {
        public static TrashCounter instance = null;    
        public int counter = 0;
        void Awake(){ instance = this; }
    }
