    protected MyMonitorCallback MonitorCallback
    public class MyClass
    {
         void Main()
         {
              MyMonitorCallback = new MonitorCallback();
              MyMonitorCallback.ApplyAccepted += new EventHander<ApplyEventArgs>(MyMonitorCallback_ApplyAccepted);
         }
         void MyMonitorCallback_ApplyAccepted(object sender, ApplyEventArgs e) {
            ..
         }
    }
