    public class RotationAxis
    {
        public static readonly AxisVector right = new Axis(Vector3.right);
        public static readonly AxisVector left = new Axis(Vector3.left);
        public static readonly AxisVector up = new Axis(Vector3.up);
        public static readonly AxisVector down = new Axis(Vector3.down);
        
        public static readonly AxisVector forward = new Axis(Vector3.forward);
        public static readonly AxisVector back = new Axis(Vector3.back);
     
        private Vector3 _value;
       
        private RotationAxis(Vector3 axis)
        {
            this._value = axis;
        }
        public static implicit operator Vector3(RotationAxis axis) 
        {
            return axis._value;
        }
    }
