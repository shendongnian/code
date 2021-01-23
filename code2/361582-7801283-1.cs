    class Type1 {
        public int DoSomething() { return 1; }
    }
    class Type2 {
        public int DoSomething() { return 2; }
    }
    static void TestDynamic() {
        dynamic t1 = Activator.CreateInstance(typeof(Type1));
        int answer1 = t1.DoSomething(); // returns 1
        dynamic t2 = Activator.CreateInstance(typeof(Type2));
        int answer2 = t2.DoSomething(); // returns 2
    }
