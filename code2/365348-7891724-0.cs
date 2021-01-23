    class A : System.Exception {}
    class B : A {}
    void Test()
    {
        try
        {
            throw new B();
        }
        catch (A a)
        {
            //as B is derived from A, this catch block will be invoked.
        }
        catch (Exception e)
        {
        }
    }
