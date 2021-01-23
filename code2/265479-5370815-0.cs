    interface IMy 
    {
        int GetFoo(string name); // calls GetFoo(name, DefautlFoo, DefaultBar)
        int GetFoo(string name, string foo); // calls GetFoo(name, foo, DefaultBar)
        int GetFoo(string name, string foo, string bar);
    }
