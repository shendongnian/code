        class MyClass
        {
            public string Name { get; set; }
            public bool Hero { get; set; }
            public int Age { get; set; }
        }
...
     Expression<Func<MyClass, bool>> expression1 = x => x.Age > (age ?? 0);
     Expression<Func<MyClass, bool>> expression2 = x => x.Name == name;
     expression1 = expression1.AndLambdas(expression2);
     result = expression1.Compile()(new MyClass { 
                Name = "Rondon", 
                Hero = true, 
                Age = 92 });
