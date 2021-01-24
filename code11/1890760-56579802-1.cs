    // The Serializable makes them actually appear in the Inspector
    // which might be very helpful in you case
    [Serializable]
    public class TransformData 
    { 
        public Vector3 position;
        public Quaternion rotation; 
        public Vector3 scale; 
    }
    
