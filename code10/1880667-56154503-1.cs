    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    class ShipInstanceCreator: MonoBehaviour
    {
        public GameObject ship;
        void Start()
        {
           GameObject player = Object.Instantiate (ship, transform.position,   transform.rotation) as GameObject;
       }
   
