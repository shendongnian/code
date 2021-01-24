    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [System.Serializable]
    public class RagdollRig
    {
        public ConfigurableJoint torso,
            pelvis,
            rightArm,
            leftArm,
            upperRightLeg,
            lowerRightLeg,
            rightFoot,
            upperLeftLeg,
            lowerLeftLeg,
            leftFoot;
    
        public Transform centerOfMass;
    
        private List<Rigidbody> _rigidbodies;
        
        public void InitializeRig()
        {
            _rigidbodies = GetRigidbodies();
        }
    
        private List<Rigidbody> GetRigidbodies()
        {
            return new List<Rigidbody>
            {
                torso.gameObject.GetComponent<Rigidbody>(),
                pelvis.gameObject.GetComponent<Rigidbody>(),
                rightArm.gameObject.GetComponent<Rigidbody>(),
                leftArm.gameObject.GetComponent<Rigidbody>(),
                upperRightLeg.gameObject.GetComponent<Rigidbody>(),
                lowerRightLeg.gameObject.GetComponent<Rigidbody>(),
                rightFoot.gameObject.GetComponent<Rigidbody>(),
                upperLeftLeg.gameObject.GetComponent<Rigidbody>(),
                lowerLeftLeg.gameObject.GetComponent<Rigidbody>(),
                leftFoot.gameObject.GetComponent<Rigidbody>()
            };
        }
    
        public Vector3 CalculateCenterOfMass()
        {
            var mass = Vector3.zero;
            float division = 0;
    
            foreach (var t in _rigidbodies)
            {
                var objMass = t.mass;
                mass += objMass * t.transform.position;
                division += objMass;
            }
    
            return mass / division;
        }
    }
    ``
