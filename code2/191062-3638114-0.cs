	public class SomeIDdClass : IEquatable<SomeIDdClass>
	{
	    private readonly int _id;
        public SomeIDdClass(int id)
        {
            _id = id;
        }
        public int Id
        {
            get { return _id; }
        }
        public bool Equals(SomeIDdClass other)
        {
            return null != other && _id == other._id;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as SomeIDdClass);
        }
        public override int GetHashCode()
        {
            return _id;
        }
    }
