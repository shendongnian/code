    var b = new B(){
        Id = 100
    };
    context.B.Attach(b);
    //OR
    context.Entry(b).State = EntityState.Unchanged;
    A.Bs.Add(b);
