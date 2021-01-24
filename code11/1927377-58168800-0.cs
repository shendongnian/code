    public interface ICommon
    {
        int SomeInt { get; }
        bool SomeBool { get; }
        float SomeFloat { get; }
    }
    public class CommonComparer : IEqualityComparer<ICommon>
    {
        public bool Equals(ICommon x, ICommon y)
        {
            return x.SomeInt.Equals(y.SomeInt)
                && x.SomeBool.Equals(y.SomeBool)
                && x.SomeFloat.Equals(y.SomeFloat);
        }
        public int GetHashCode(ICommon obj)
        {
            unchecked
            {
                int hc = -1817952719;
                hc = (-1521134295)*hc + obj.SomeInt.GetHashCode();
                hc = (-1521134295)*hc + obj.SomeBool.GetHashCode();
                hc = (-1521134295)*hc + obj.SomeFloat.GetHashCode();
                return hc;
            }
        }
    }
