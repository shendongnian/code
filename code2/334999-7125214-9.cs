			MyClass Test1 = new MyClass();
			Test1.Property1 = 1;
			Test1.Property2 = 2;
			Test1.Property3 = "Property3String";
			Test1.Property4 = 4.0;
			Test1.Property5 = "Property5String";
			Test1.PropertyDontCopy = 100.0;
			Test1.PropertyIgnoreMe = new int[] { 0, 1, 2, 3 };
			Test1.PropertyOnlyClass3 = "Class3OnlyString";
			Test1.StringArray = new string[] { "String0", "String1", "String2" };
			Test1.TestIntToString = 123456;
			Test1.TestStringToInt = "654321";
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Copying: Test1 to Test2");
			Console.WriteLine("-------------------------------------");
			MyClass2 Test2 = new MyClass2();
			Test2.CopyFrom(Test1);
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Copying: Test1 to Test3");
			Console.WriteLine("-------------------------------------");
			MyClass3 Test3 = new MyClass3();
			Test3.CopyFrom(Test1);
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Done");
			Console.WriteLine("-------------------------------------");
		}
	}
