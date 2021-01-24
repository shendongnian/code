    public class RotationAxis
    {
        public static readonly AxisVector x = new Axis(Vector3.right);
        public static readonly AxisVector y = new Axis(Vector3.up);
        public static readonly AxisVector z = new Axis(Vector3.forward);
     
        public readonly Vector3 value;
       
        private RotationAxis(Vector3 axis)
        {
            this.value = axis;
        }
        public static implicit operator Vector3(RotationAxis axis) 
        {
            return axis.value;
        }
    }
