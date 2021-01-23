	string A = "hello, world";
	string s = A; // Expression context
	A a=new A();
	Type t = typeof(A); // Type context
	Console.WriteLine(s); // Writes "hello, world"
	Console.WriteLine(t); // Writes "A"
