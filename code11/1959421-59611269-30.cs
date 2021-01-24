    public interface Num<A>
    {
        A Add(A lhs, A rhs);
        A Subtract(A lhs, A rhs);
        A Multiply(A lhs, A rhs);
        A Divide(A lhs, A rhs);
        A FromInt(int value);
        A One { get; }
        A Zero { get; }
    }
    public interface Eq<A>
    {
        bool IsEqualTo(A lhs, A rhs);
        // using C#8 default interface methods
        bool IsNoEqualTo(A lhs, A rhs) => !IsEqualTo(lhs, rhs); 
    }
