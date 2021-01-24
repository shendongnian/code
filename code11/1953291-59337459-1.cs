    dynamic[] collection = new dynamic[] {new A(), new B(), new C()};
    UpdateObjects(collection);
    // Result
    foreach (dynamic o in collection)
    {
        int p = o.P;
        Debug.WriteLine(p);
    }
