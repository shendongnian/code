    public class A : ICommonDeviceInterface 
    {
      public int AMember;
    }
    public class B :ICommonDeviceInterface 
    {
      public int BMember;
    }
    foreach (ICommonDeviceInterface device in Form1.deviceList)
    {
        
        if(device is A)
        {
           A a = device as A;
           a.AMember = 100;
        }
        else if(device is B)
        {
           B b = device as B;
           b.BMember = 123;
        }
    }
    
