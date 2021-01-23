    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security;
    using System.Security.Permissions;
    using System.Diagnostics;
    using System.Reflection;
    
    namespace SandboxTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Sandbox sandbox = new Sandbox();
                Console.ReadLine();
            }
        }
    
        class Sandbox
        {
            AppDomain domain;
    
            public Sandbox()
            {
                PermissionSet ps = new PermissionSet(PermissionState.None);
                ps.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
    
                try
                {
                    domain = AppDomain.CreateDomain("Sandbox", AppDomain.CurrentDomain.Evidence, AppDomain.CurrentDomain.SetupInformation, ps);
                    var tp = typeof(MyInit);
    
                    var obj = (MyInit)domain.CreateInstanceAndUnwrap(tp.Assembly.FullName, tp.FullName);
                    var myCallBack = new MyCallBack();
                    myCallBack.Generated += new EventHandler(myCallBack_Generated);
                    obj.Subscribe(myCallBack);
                    obj.GenerateCallBackEvent();
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.ToString());
                    throw e;
                }
            }
    
            void myCallBack_Generated(object sender, EventArgs e)
            {
                //Executed in parent domain
            }
    
    
    
        }
    
    
        public class MyCallBack:MarshalByRefObject
        {
            public void GenerateEvent()
            {
                //Executed in parent domain, but triggered by sandbox domain
                if (Generated != null) Generated(this, null);
            }
    
            //for parent domain only
            public event EventHandler Generated;
        }
    
        public class MyInit:MarshalByRefObject
        {
            public MyInit()
            {
    
            }
            MyCallBack callback;
            public void Subscribe(MyCallBack callback)
            {
                //executed on sandbox domain
                this.callback = callback;
            }
    
            public void GenerateCallBackEvent()
            {
                //executed on sandbox domain
                callback.GenerateEvent();
            }
    
    
        }
    }
