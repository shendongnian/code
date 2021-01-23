    public struct Nullable2<T> where T: struct
    {
    }
    // Both lines will generate the same error
    Nullable2<Nullable<int>> v;
    Nullable<Nullable<int>> v2;
