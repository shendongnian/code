    // On Moo.Foo initialization, if the condition for creating of RealMooFoo are not met.
    Moo.Foo = new MooFooNull(this);
    // later on ...
    Moo.Foo.Show(TrType, LabelType, Moo.Foo.DangerousNullRef + " - " + Moo.Foo.AnotherPossibleNullRef);
    where MooFooNull's Show method is:
    void Show(TheClass theClass, object trType, ... ) {
        theClass.DontShowField(trType);
    }
