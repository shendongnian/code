    public static void Main()
    {
        MyObject object1 = new MyObject();
        MyObject object2 = new MyObject();
        // ...Code that changes object1 and/or object2...
        //Here's your answer: a list of what's different between the 2 objects, and each of their different values.
        //No type parameters are needed here- typeof(MyObject) is implied by the coincident types of both parameters.
        List<MemberComparison> changes = ReflectiveCompare(object1, object2);
    }
