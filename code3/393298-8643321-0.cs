    class A {
        public string prop { get; set; }
    }
    public void test(A a)
    {
        a = new A(); // NO, it's a new ref
        a.prop = "foo"; // Yes, you modify the object it's not a new ref.
    }
    public void test2(string s)
    {
        s = "bar"; // Equivalent to s = new String("bar"), so it's a new ref.
    }
    
