    class Test2 {
        // all code of class Test2
    
        public static explicit operator Test2(Test v)
        {
            return new Test2 { Name = v.Name, Score = v.Score };
        }
    }
