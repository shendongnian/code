    [Serializable]
    public class TransformData
    {
        public Vector3 LocalPosition;
        public Vector3 LocalEulerRotation;
        public Vector3 LocalScale;
    
        // Unity requires a default constructor for serialization
        public TransformData() { }
    
        public TransformData(Transform transform)
        {
            LocalPosition = transform.localPosition;
            LocalEulerRotation = transform.localEulerAngles;
            LocalScale = transform.localScale;
        }
        
        public void ApplyTo(Transform transform)
        {
            transform.localPosition = LocalPosition;
            transform.localEulerAngles = LocalEulerRotation ;
            transform.localScale = LocalScale;
        }
    }
    
