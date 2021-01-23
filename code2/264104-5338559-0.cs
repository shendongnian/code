    var ie = db.Query( ... );
    var ie2 = ie.Select(i => new MyIe2Object {
       Prop1 = i.Prop1,
       NewProp = i.Prop1 + i.Prop2
    });
