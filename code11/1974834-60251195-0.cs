     [Service(
          Name = "com.sample.MyApp.MyConnectionService", 
          Permission = Manifest.Permission.BindTelecomConnectionService, 
          Enabled = true)]
     public class MyConnectionService : ConnectionService
     {
     }
