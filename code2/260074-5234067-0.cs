    public class MonitoringData : IMonitoringData
    {
       public void DoWork(string message)
       {
        
          Form1 monitorForm = (Form1)Form1.ActiveForm;
          monitorForm.WriteMessage(message);          
       }
    }
