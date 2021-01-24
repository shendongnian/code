        public delegate T OperationDelegate<T>(dynamic a, dynamic b);
		public OperationDelegate<T> GetFunction<T>(string op)
		{
			if (op == "sum")
			{
				return (a, b) => a + b;
				
			}
			else
			if(op == "max") {
				return (a, b) => Math.Max(a, b);
			}
			throw new InvalidOperationException();
		}
    
    // Use as: 
    var myOp = GetFunction<double>("sum");
	double result = myOp(1.0, 2.0);
