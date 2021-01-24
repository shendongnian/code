class C : A, B
{
    void A.Method()
    {
        // explicit implementation of interface A
    }
    
    void B.Method()
    {
        // explicit implementation of interface B
    }
    
    public void Method()
    {
        // class implementation
    }
}
You should be aware of how to invoke the particular methods.
var c = new C();
c.Method();       // class implementation
((B)c).Method();  // implementation of B
((A)c).Method();  // implementation of A
