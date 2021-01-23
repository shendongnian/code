    StringBuilder a = null, b = null; // both variables empty
    a = new StringBuilder("a"); // a ref to the obj, b empty
    b = a; // copy value (ref) of a to b: a and b both ref to obj
    b.Append("b"); // no change to either VARIABLE; the OBJECT has changed state
    b = null; // clear the variable b; a still points to the obj
