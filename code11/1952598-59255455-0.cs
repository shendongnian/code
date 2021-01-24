    public class Transform
    {
        public Transform Parent;
        public Position GlobalPosition;
        public Position LocalPosition => Parent.GlobalPosition - GlobalPosition;
        public Rotation GlobalRotation;
        public Rotation LocalRotation => Parent.GlobalRotation - GlobalRotation; 
        public Scale GlobalScale;
        public Scale LocalScale => Parent.GlobalScale - GlobalScale; 
    }
