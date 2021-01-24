    public class UpdateLineScript : MonoBehaviour
    {
        [SerializeField] LineRenderer line;
    
        private Transform _parentTransform;
        private Transform _childTransform;
    
        private Vector3[] positions = new Vector3[2];
    
        public void Initialize (Transform parentTransform, Transform childTransform, string newName)
        {
            name = newName;
            if(!line) line = GetComponent<LineRenderer>();
            _parentTransform = parentTransform;
            _childTransform = childTransform;
    
            line.pointCount = 2;
        }
    
        private void Update()
        {
            positions[0] = parentTransform.position;
            positions[1] = childTransform.position; 
    
            line.SetPositions(positions);
        }
    }
