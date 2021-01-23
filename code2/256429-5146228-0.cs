    using System;
    using System.Net;
    using System.Reflection;
    
    public class WSTest
    {
       public static void Main(string[] args)
       {
          // read command line args
          String methodName = args[0]; // the first command line arg
          String userName = args[1]; // the second command line arg
          String password = args[2]; // the third command line arg
    
          // create an instance of your service w/ network credentials
          MyService s = new MyService();
          s.Credentials = new NetworkCredentials(userName, password);
          // dynamically invoke method using reflection
          Type t = typeof(s);
          MethodInfo mi = t.GetMethod(methodName);
          mi.Invoke(s, null);
       }
    }
