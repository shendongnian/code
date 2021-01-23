    class Generic<T>
    {
	    public T value;
    }
    
    static class Extension
    {
	    public static void Add (this Generic<float> generic)
	    {
		    generic.value += 1.0f;
	    }
    }
