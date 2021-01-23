    System.Object a = new System.Object();
    System.Object b = new System.Object();
    a == b;      //returns true
    a.Equals(b); //returns false
    b = a;
    a == b;      //returns true
    a.Equals(b); //returns true
