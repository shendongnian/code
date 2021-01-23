    void foo()
    {
       Vector v1 = new MyVector(10);    // type MyVector
       Vector v2 = new MyVector(20);    // type MyVector
       Vector v3 = v1 + v2;             // Vector.operator + called
       bar(v1, v2);
    }
    void bar(Vector p_v1, Vector p_v2)
    {
       dynamic v1 = p_v1;               // dynamic type
       dynamic v2 = p_v2;               // dynamic type
       Vector v3 = v1 + v2;             // MyVector.operator + called
    }
