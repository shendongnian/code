    class Vector
    {
		public Vector VectorMethod1()
		{
             return this;
		}
	}
    Vector vector1 = (new Vector { X = 1, Y = 1 }).VectorMethod1();
