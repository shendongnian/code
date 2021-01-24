    // In order to be able to actually save that list this class has to be
    // Serializable!
    // Another nice side effect is that from now you can also adjust the values
    // from the Inspector of the MonoBehaviour using such an instance or list
    [Serializable]
    public class TransformData 
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    
        // Serialization always needs a default constructor 
        // doesn't have to do anything but can
        public TransformData() 
        {
            // scale should be 1,1,1 by default
            // The other two can keep their default values
            scale = Vector3.one;
        }
        public TransformData(Vector3 pos, Quaternion rot, Vector3 scal)
        {
            position = pos;
            rotation = rot;
            scale = scal;
        }
    }
