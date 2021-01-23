    Person1 = new Person("David", "Burris");
    Person2 = new Person("Johnny", "Carrol");
    Person3 = new Person("Ji", "Jihuang");
    //The Add method takes Key as the first parameter and Value as the second parameter.
    
    try
    {
        MyTable.Add(Person1.Lname, Person1);
    	MyTable.Add(Person2.Lname, Person2);
    	MyTable.Add(Person3.Lname, Person3);
    				
    }
    catch (ArgumentException ae)
    {
    	MessageBox.Show("Duplicate Key");
    	MessageBox.Show(ae.Message);
    }
