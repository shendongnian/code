    public void SomeMethod(A a, int i, float f, string s = "") { }
    public void SomeMethod(int i, float f, string s = "")
    {
        SomeMethod(new A(), i, f, s);
    }
