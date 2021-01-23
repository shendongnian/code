    namespace N2
    {
    	using W = N1.A;      	// Error, cannot name unbound generic type
    	using X = N1.A.B;			// Error, cannot name unbound generic type
    	using Y = N1.A<int>;		// Ok, can name closed constructed type
    	using Z<T> = N1.A<T>;	// Error, using alias cannot have type parameters
    }
