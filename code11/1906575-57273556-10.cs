    /// <summary>
    /// Returns the internal multidimensional array of this matrix if, and only if, this matrix is stored by such an array internally.
    /// Otherwise returns null. Changes to the returned array and the matrix will affect each other.
    /// Use ToArray instead if you always need an independent array.
    /// </summary>
    public T[,] AsArray()
    {
    	return Storage.AsArray();
    }
