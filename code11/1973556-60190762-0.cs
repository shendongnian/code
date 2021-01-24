    using UnityEngine;
    public class Pressable : MonoBehaviour
    {
        [SerializeField] protected bool active = false;
        [SerializeField] AudioSource pressSound = null;
        
        protected virtual void Start()
        {
        }
        public virtual void Press()
        {
            if (pressSound != null) { pressSound.Play(); }
            active = !active;
        }
    }
