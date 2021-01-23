    Tiger tony = new Tiger();
    Elephant dumbo = new Elephant();
    ImmutableStack<Tiger> tigers = ImmutableStack<Tiger>.Empty;
    tigers = tigers.Push<Tiger>(tony);
    ImmutableStack<Mammal> mammals = tigers.Push<Mammal>(dumbo);
