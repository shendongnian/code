    public class A {}
    public class B: A {}
    public class C: A {}
   
    void Main()
    {
        //Hmmm... I need a IList<T>, let's call MyMethod!
        IList<A> list = MyMethod();
        //Cool, I got an IList<A>, now let's add some items...
        var item = new C();
        //Well, item is of type C...
        // and C inherits from A, so I must be able to add it...
        list.Add(item); //BOOM!
        //It was actually an IList<B>!
        // and C doesn't dervive from B, so you can't add it.
    }
