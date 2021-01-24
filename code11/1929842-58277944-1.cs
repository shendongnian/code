         		...
         ...
         //populate list with testing instances
         var list = new ListRule();
         var c1 = new Class1() { Name = "Class #1", Age = "11" };
         list.List.Add(c1);
         var c2 = new Class2() { Name = "Class #2", Age = "22" };
         list.List.Add(c2);
		 
		 ...
		 //then, get only certain types, and populate second list "myList": for example, pull only of type Class1:
		 public  void Test2(List<IClassAbsract> list)
		 {
		 		 if (list == null || !list.Any())
		 		 {
		 		 		 throw new System.ArgumentNullException("empty");
		 		 }
		 		 //pull only of type Class1:
		 		 List<IClassAbsract> myList = new List<IClassAbsract>();
		 		 myList.AddRange(list
		                .Where(e => e is Class1)
         		 		 .Select(e => new Class1() { Age = e.Age, Name = "Joe" })
		 		 		 .ToList()
		 		 );
        }
