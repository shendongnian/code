    List<MyPosition> Sequence= new List<MyPosition>();
    Sequence.Add(new MyPosition() { Position = 1, Headerobject });
    Sequence.Add(new MyPosition() { Position = 2, Headerobject1 });
    Sequence.Add(new MyPosition() { Position = 1, Footer });
    League.Sort((PosA, PosB) => PosA.Position.CompareTo(PosB.Position));
