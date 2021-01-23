    using (var ctx = new MyContext())
    {
        var parent = new Parent();
        var child1 = new Child();   // <- Id is 0
        var child2 = new Child();   // <- Id is 0 as well
        parent.Children.Add(child1);
        parent.Children.Add(child2);
        ctx.Parents.Attach(parent);  // <- exception here
        //...
    }
