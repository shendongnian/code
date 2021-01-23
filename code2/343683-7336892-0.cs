    class blueBox : IBox
    {
     //here you will have your concrete implementations of the above methods and properties
    public Bool visibility   {get; set;} // this doesn't make sense with auto getter setters. you would need to write your bluebox specific getter and setters
    }
    
    class redBox : IBox
    {
    //more concrete implementation
    }
    public myMethod_To_Do_Stuff(IBox myBox) { // see how I am passing the interface not the conrete classes
    
    myBox.visibility = true;
    
    }
