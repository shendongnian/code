    using System.Threading;
    
---
    // Somewhere in your Form, for example in Form_Load event:
    new Thread(new ThreadStart(delegate {
        var d = new setLabelTextDelegate(setLabelText);
        label1.Invoke(d, new object[] { "string 1" });
        System.Threading.Thread.CurrentThread.Sleep(3000); // sleep 3 seconds
        label1.Invoke(d, new object[] { "string 2" });
        System.Threading.Thread.CurrentThread.Sleep(5000); // sleep 5 seconds
        label1.Invoke(d, new object[] { "string 3" });
    })).Start();
