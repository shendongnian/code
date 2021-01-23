	int a = Test.Foo(2,3);
	int b = Test.Foo2(2,3);
	
	Console.WriteLine("{0}, {1}",a,b); // 5, 5, all seems good, they're both sums
	
        //... but wait... now you can do this:
	Test.Foo = (x,y) => x * y; //reassigning Foo
	int c = Test.Foo(2,3);
	Console.WriteLine("{0}",c); // 6 
