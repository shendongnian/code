    static void M(Animal x, Animal y) {}
    static void M(Animal x, Tiger y) {}
    static void M(Giraffe x, Tiger y) {}
    ...
    dynamic ddd = new Tiger();
    Animal aaa = new Giraffe();
    M(aaa, ddd);
