    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class FollowPlatform : MonoBehaviour
    {
        public Transform platform;
        public Vector2 offset;
        // Update is called once per frame
        void Update()
        { 
            transform.position = platform.position + offset;
        }
    }
