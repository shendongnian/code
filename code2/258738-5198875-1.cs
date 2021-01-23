    private void Form1_Load(object sender, EventArgs e)
    {
        var helper1 = new TestDelegates.Form1.MyClass.HelperDelegate(Testing);
        var helper2 = new TestDelegates.Form1.MyClass.HelperDelegate(Testing2);
        var myClass1 = new MyClass(helper1);
        var myClass2 = new MyClass(helper1);
        System.Diagnostics.Debug.Print(myClass1.Equals(myClass2).ToString());
     //true
        myClass2 = new MyClass(helper2);
        System.Diagnostics.Debug.Print(myClass1.Equals(myClass2).ToString());
     //false
    }
    private object Testing()
    {
        return new object();
    }
    private object Testing2()
    {
        return new object();
    }
    public class MyClass : IEquatable<MyClass>
    {
       public delegate object HelperDelegate();
       protected internal HelperDelegate _myHelperDelegate;
       public MyClass(HelperDelegate helper)
       {
         _myHelperDelegate = helper;
       }
       public bool Equals(MyClass other)
       {
          if (_myHelperDelegate == other._myHelperDelegate)
          {
             return true;
          }
          return false;
       }
    }
