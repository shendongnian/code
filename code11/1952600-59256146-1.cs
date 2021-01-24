    public interface ISubtractable<T>
    {
        T Subtract(T subtrahend);
    }
    public abstract class Position
    {
        public float[] Axis;
        public Position(int axis)
        {
            Axis = new float[axis];
        }
        public Position(float[] axis)
        {
            Axis = axis;
        }
    }
    public class DerivedPosition : Position, ISubtractable<DerivedPosition>
    {
        public DerivedPosition(int axis)
            : base(axis)
        { }
        public DerivedPosition(float[] axis)
            : base(axis)
        { }
        public DerivedPosition Subtract(DerivedPosition subtrahend)
        {
            if(Axis == subtrahend.Axis)
            {
                throw new System.Exception("The axis of the two Positions are not comparable.");
            }
            DerivedPosition difference = new DerivedPosition(Axis);
            for (int i = 0; i < difference.Axis.Length; i++)
            {
                difference.Axis[i] = Axis[i] - subtrahend.Axis[i];
            }
            return difference;
        }
    }
    public class Transform<TPosition, TRotation, TScale>
        where TPosition : ISubtractable<TPosition>
        where TRotation : ISubtractable<TRotation>
        where TScale : ISubtractable<TScale>
    {
        public Transform<TPosition, TRotation, TScale> Parent;
        public TPosition GlobalPosition;
        public TPosition LocalPosition => Parent.GlobalPosition.Subtract(GlobalPosition);
        // etc.
    }
