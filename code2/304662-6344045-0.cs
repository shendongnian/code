    public static void Main()
    {
        // Declare a StudentName by using the constructor that has two parameters.
        StudentName student1 = new StudentName("Craig", "Playstead");
        // Make the same declaration by using a collection initializer and sending 
        // arguments for the first and last names. The default constructor is 
        // invoked in processing this declaration, not the constructor that has
        // two parameters.
        StudentName student2 = new StudentName
        {
            FirstName = "Craig",
            LastName = "Playstead",
        };
        // Declare a StudentName by using a collection initializer and sending 
        // an argument for only the ID property. No corresponding constructor is
        // necessary. Only the default constructor is used to process object 
        // initializers.
        StudentName student3 = new StudentName
        {
            ID = 183
        };
        // Declare a StudentName by using a collection initializer and sending
        // arguments for all three properties. No corresponding constructor is 
        // defined in the class.
        StudentName student4 = new StudentName
        {
            FirstName = "Craig",
            LastName = "Playstead",
            ID = 116
        };
        System.Console.WriteLine(student1.ToString());
        System.Console.WriteLine(student2.ToString());
        System.Console.WriteLine(student3.ToString());
        System.Console.WriteLine(student4.ToString());
    }
    // Output:
    // Craig  0
    // Craig  0
    //   183
    // Craig  116
