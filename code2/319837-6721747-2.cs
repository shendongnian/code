    namespace Demo
    {
     public delegate void FrobCallback(int frobberID);
    //Invalid Syntax - Can't pass in parameters to the delegate method this way.
    BeginFrob(MyFrobCallback(10))
    }
