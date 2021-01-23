    List<string> myList = new List<string>();
    var task1 = Task.Factory.StartNew( () => new MyClass1().Load() );
    var task2 = Task.Factory.StartNew( () => new MyClass2().Load() );
    var task3 = Task.Factory.StartNew( () => new MyClass3().Load() );
    myList.AddRange(task1.Result);
    myList.AddRange(task2.Result);
    myList.AddRange(task3.Result);
    myList.DoSomethingWithValues();
