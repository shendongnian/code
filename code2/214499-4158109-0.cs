    class Program
    {
        public static void Main(string[] args)
        {
            var boundedOpenInterval = Interval<int>.Bounded(0, Edge.Open, 10, Edge.Open);
            var boundedClosedInterval = Interval<int>.Bounded(0, Edge.Closed, 10, Edge.Closed);
            var smallerInterval = Interval<int>.Bounded(3, Edge.Closed, 7, Edge.Closed);
            var leftBoundedOpenInterval = Interval<int>.LeftBounded(10, Edge.Open);
            var leftBoundedClosedInterval = Interval<int>.LeftBounded(10, Edge.Closed);
            var rightBoundedOpenInterval = Interval<int>.RightBounded(0, Edge.Open);
            var rightBoundedClosedInterval = Interval<int>.RightBounded(0, Edge.Closed);
            Assert.That(
                boundedOpenInterval.Includes(smallerInterval)
            );
            Assert.That(
                boundedOpenInterval.Includes(5)
            );
            Assert.That(
                leftBoundedClosedInterval.Includes(100)
            );
            Assert.That(
                !leftBoundedClosedInterval.Includes(5)
            );
            Assert.That(
                rightBoundedClosedInterval.Includes(-100)
            );
            Assert.That(
                !rightBoundedClosedInterval.Includes(5)
            );
        }
    }
    public class Interval<T> where T : struct, IComparable<T>
    {
        private T? _left;
        private T? _right;
        private int _edges;
        private Interval(T? left, Edge leftEdge, T? right, Edge rightEdge)
        {
            if (left.HasValue && right.HasValue && left.Value.CompareTo(right.Value) > 0)
                throw new ArgumentException("Left edge must be lower than right edge");
            _left = left;
            _right = right;
            _edges = (leftEdge == Edge.Closed ? 0x1 : 0) | (rightEdge == Edge.Closed ? 0x2 : 0);
        }
        public T? Left
        {
            get { return _left; }
        }
        public Edge LeftEdge
        {
            get { return _left.HasValue ? ((_edges & 0x1) != 0 ? Edge.Closed : Edge.Open) : Edge.Unbounded; }
        }
        public T? Right
        {
            get { return _right; }
        }
        public Edge RightEdge
        {
            get { return _right.HasValue ? ((_edges & 0x2) != 0 ? Edge.Closed : Edge.Open) : Edge.Unbounded; }
        }
        public bool Includes(T value)
        {
            var leftCompare = CompareLeft(value);
            var rightCompare = CompareRight(value);
            return
                (leftCompare == CompareResult.Equals || leftCompare == CompareResult.Inside) &&
                (rightCompare == CompareResult.Equals || rightCompare == CompareResult.Inside);
        }
        public bool Includes(Interval<T> interval)
        {
            var leftEdge = LeftEdge;
            if (leftEdge != Edge.Unbounded)
            {
                if (
                    leftEdge == Edge.Open &&
                    interval.LeftEdge == Edge.Closed &&
                    interval._left.Equals(_left)
                )
                    return false;
                if (interval.CompareLeft(_left.Value) == CompareResult.Inside)
                    return false;
            }
            var rightEdge = RightEdge;
            if (rightEdge != Edge.Unbounded)
            {
                if (
                    rightEdge == Edge.Open &&
                    interval.RightEdge == Edge.Closed &&
                    interval._right.Equals(_right)
                )
                    return false;
                if (interval.CompareRight(_right.Value) == CompareResult.Inside)
                    return false;
            }
            return true;
        }
        private CompareResult CompareLeft(T value)
        {
            var leftEdge = LeftEdge;
            if (leftEdge == Edge.Unbounded)
                return CompareResult.Equals;
            if (leftEdge == Edge.Closed && _left.Value.Equals(value))
                return CompareResult.Inside;
            return _left.Value.CompareTo(value) < 0
                ? CompareResult.Inside
                : CompareResult.Outside;
        }
        private CompareResult CompareRight(T value)
        {
            var rightEdge = RightEdge;
            if (rightEdge == Edge.Unbounded)
                return CompareResult.Equals;
            if (rightEdge == Edge.Closed && _right.Value.Equals(value))
                return CompareResult.Inside;
            return _right.Value.CompareTo(value) > 0
                ? CompareResult.Inside
                : CompareResult.Outside;
        }
        public static Interval<T> LeftBounded(T left, Edge leftEdge)
        {
            return new Interval<T>(left, leftEdge, null, Edge.Unbounded);
        }
        public static Interval<T> RightBounded(T right, Edge rightEdge)
        {
            return new Interval<T>(null, Edge.Unbounded, right, rightEdge);
        }
        public static Interval<T> Bounded(T left, Edge leftEdge, T right, Edge rightEdge)
        {
            return new Interval<T>(left, leftEdge, right, rightEdge);
        }
        public static Interval<T> Unbounded()
        {
            return new Interval<T>(null, Edge.Unbounded, null, Edge.Unbounded);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            var other = obj as Interval<T>;
            if (other == null)
                return false;
            return
                ((!_left.HasValue && !other._left.HasValue) || _left.Equals(other._left)) &&
                ((!_right.HasValue && !other._right.HasValue) || _right.Equals(other._right)) &&
                _edges == other._edges;
        }
        public override int GetHashCode()
        {
            return
                (_left.HasValue ? _left.GetHashCode() : 0) ^
                (_right.HasValue ? _right.GetHashCode() : 0) ^
                _edges.GetHashCode();
        }
        public static bool operator ==(Interval<T> a, Interval<T> b)
        {
            return ReferenceEquals(a, b) || a.Equals(b);
        }
        public static bool operator !=(Interval<T> a, Interval<T> b)
        {
            return !(a == b);
        }
        public override string ToString()
        {
            var leftEdge = LeftEdge;
            var rightEdge = RightEdge;
            var sb = new StringBuilder();
            if (leftEdge == Edge.Unbounded)
            {
                sb.Append("(-∞");
            }
            else
            {
                if (leftEdge == Edge.Open)
                    sb.Append('(');
                else
                    sb.Append('[');
                sb.Append(_left.Value);
            }
            sb.Append(',');
            if (rightEdge == Edge.Unbounded)
            {
                sb.Append("∞)");
            }
            else
            {
                sb.Append(_right.Value);
                if (rightEdge == Edge.Open)
                    sb.Append(')');
                else
                    sb.Append(']');
            }
            return sb.ToString();
        }
        private enum CompareResult
        {
            Inside,
            Outside,
            Equals
        }
    }
    public enum Edge
    {
        Open,
        Closed,
        Unbounded
    }
