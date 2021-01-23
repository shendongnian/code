    private void MyFirstMethod(int myVar)
    {
        Console.WriteLine(myVar);
    }
    private void MySecondMethod(int myVar)
    {
        MyFirstMethod(myVar); // Call with the value of the parameter myVar
        MyFirstMethod(myVar: myVar); // Same as before, but explicitly naming the parameter
        MyFirstMethod(5); // Call with the value 5
        MyFirstMethod(myVar: 5); // Same as before, but explicitly naming the parameter
    }
