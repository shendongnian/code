        [SerializeField] private new Rigidbody rigidbody; // assign in the inspector
        
        private void OnCollisionEnter(Collision collision)
        {
            // add check if we hit the wall and not something else
            // e.g. via the name, tag or layer of collision.gameObject
            rigidbody.enabled = false;
            // alternatively, freeze the rigidbody or make it's velocity 0 and make it not be affected by gravity, etc.
        }
    }
