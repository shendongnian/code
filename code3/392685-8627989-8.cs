    void Add(ref double _y, double s) {
        // _y = 5
        _y += s;
        // _y = 8.5
    }
    double y = 5;
    Add(ref y, 3.5);
    // y = 8.5 
