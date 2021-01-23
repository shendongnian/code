    class A
    {
    	public static bool operator ==(A x, A y) { return true; }
    	public static bool operator !=(A x, A b) { return false; }
    }
    
    class B : A { }
    
    class AComparer<T> where T : A
    {
    	public bool CompareEqual(T x, T y) { return x == y; }
    }
