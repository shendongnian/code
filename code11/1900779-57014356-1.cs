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
            destTransform.position = playerTransform.position + playerToDestHand ;
    
            // Determine dest rotation
            Vector3 forwardVec = ReflectRelativeVector(sourceTransform.forward);
            Vector3 upVec = ReflectRelativeVector(sourceTransform.up);
            destTransform.rotation.SetLookRotation(forwardVec,upVec);
        }
       
        Vector3 ReflectRelativeVector(Vector3 relativeVec) 
        {
           return relativeVec 
               + playerTransform.right 
                   * -2f 
                   * Vector3.Dot(relativeVec, playerTransform.right);
        }
    }
