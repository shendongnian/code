    public class VRMirror : MonoBehaviour
    {
        public bool mirrorLeft;
        public bool mirrorRight;
        public GameObject leftHand; //left hand anchor in OVRCameraRig
        public GameObject rightHand; //right hand anchor from OVRCameraRig
        public Transform playerTransform;  
        void Start()
        {
        }
        void FixedUpdate()
        {
            Transform left = leftHand.GetComponent<Transform>();
            Transform right = rightHand.GetComponent<Transform>();
            if (mirrorLeft)
            {
                 MirrorFromTo(left, right);
            }
            else if (mirrorRight)
            {
                MirrorFromTo(right, left);
               
            }
        }
        void MirrorFromTo(Transform sourceTransform, Transform destTransform)
        {
            // Determine dest position
            Vector3 playerToSourceHand = sourceTransform.position - playerTransform.position;
            Vector3 playerToDestHand = ReflectRelativeVector(playerToSourceHand);
            destTransform.position = playerTransform.position + playerToDestHand;
            // Determine dest rotation
            Quaternion destRot = sourceTransform.rotation;
  
            destRot.y = -destRot.y;
            destRot.z = -destRot.z;
            destTransform.rotation = destRot;
        }
        Vector3 ReflectRelativeVector(Vector3 relativeVec)
        {
            // relativeVec
            //     Take the relative vector....
            // + Vector3.Dot(relativeVec, playerTransform.right)
            //     and for how far along the player's right direction it is 
            //     away from the player (may be negative),
            // * playerTransform.right
            //     move it that distance along the player's right...
            // * -2f
            //    negative two times (i.e., along the left direction 2x)
            return relativeVec
            + Vector3.Dot(relativeVec, Vector3.right)
                * Vector3.right
                * -2f;
        }
    }
