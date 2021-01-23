    public class MonitoringData : IMonitoringData
    {
       public void DoWork(string message)
       {
        
           Form1 monitorForm = (Form1)System.Windows.Forms.Application.OpenForms[0];
           monitorForm.WriteMessage(message);            
       }
    }
