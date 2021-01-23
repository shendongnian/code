     protected static object _lockObj = new object();
     protected static bool _isHandled = false;    
     void MyClass_MyEvent(object sender, EventArgs e)
     {
         if(_isHandled)
           return;
         lock(_lockObj)
         {
             if(_isHandled)
                return;
             _isHandled = true;
             MyOtherPossiblyRecursiveMethod(); // Actually does all your work
             _isHandled = false;
         }
     }
     void MyOtherPossiblyRecursiveMethod()
     {
     }
