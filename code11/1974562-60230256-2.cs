    public struct TransformInfo
    {
        public string ID;
        public Transform Transform;
        public Vector3 pos;
        public Quaternion rot;
        public Vector3 scale;
        public TransformInfo(Transform transform, int id)
        {
            Transform = transform;
            ID = id;
            // For this kind of stuff I always prefer working on the local values
            pos = transform.localPosition;
            rot = transform.localRotation;
            scale = transform.localScale;
        }
        public void Apply()
        {
            Transform.localPosition = pos;
            Transform.localRotation = rot;
            Transform.localScale = scale;
        }
        public void Apply(Transform transform)
        {
            transform.localPosition = pos;
            transform.localRotation = rot;
            transform.localScale = scale;
        }
    }
