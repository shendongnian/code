    public class MyClass
        {
            public void Mymethod()
            {
                DBConnect db = new DBConnect();//Object creation
                List<string>[] result = db.Select("MyQuery");//Method (Function) calling
                foreach (List<string> item in result)//To access each List<string> from the array of List<string>
                {   // Do something with item if required
                    foreach (string innerItem in item) // To access each string from the List<string>
                    {
                        //Do something with innerItem
                    }
                }
    
            }
        }
