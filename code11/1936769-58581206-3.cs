    var b = new B();
    b.DoA();
	b.DoB();
		
	var c = new C();
    c.DoA();           // Prints: DoA in B.
	(c as IA).DoA();   // Prints: DoA in C.
