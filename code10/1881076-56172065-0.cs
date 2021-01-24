	struct A
    {
        public int Value;
        public A(int value)
        {
            Value = value;
        }
		// This allows creating an instance of struct A by writing it as an assignment statement
		static public implicit operator A(int value)
    	{
	        return new A(value);
    	}
        public override string ToString()
        {
            return Value.ToString();
        }
	}
	
	public static void Main()
	{
		A Number = 9;
        Console.Write(Number);
	}
