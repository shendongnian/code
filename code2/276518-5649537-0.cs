    public partial class EmailService : ServiceBase
    {
        Thread _thread = new Thread(DoAlways)
    
         protected override void OnStart(string[] args)
         {
            _thread.Start();
         }
         private void DoAlways()
         {
            while()
            {
               // ...
            }
         }
