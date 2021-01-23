    public abstract class Scalar<This> where This : Scalar<This>
    {
        public static This operator +(Scalar<This> a, This b) => a.Add(b);
        public abstract This Add(This another);
        ...
     }
