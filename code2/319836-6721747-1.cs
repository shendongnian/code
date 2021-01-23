    using Demo; //Needed to access the FooDelegate and Widget class.
    
    namespace YourApp
    {
    public class WidgetUser
    {
    private Widget widget; //initialization skipped for brevity.
    
    private void MyFooCallback()
    {
    //This is our callback method for StartFoo. Note that it has a void return type
    //and no parameters, just like the definition of FooCallback. The signature of
    //the method you pass as a delegate parameter MUST match the definition of the
    //delegate, otherwise you get a compile-time error.
    }
    public void UseWidget()
    {
    //Call StartFoo, passing in `MyFooCallback` as the value of the callback parameter.
    widget.BeginFoo(MyFooCallback);
    }
    }
    }
