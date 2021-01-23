    public class MyApp : Application
    {
       public override OnStartup(EventArgs e)
       {
           base.OnStartup(e);
    
           MyData data = FindResource("MyData");
    
           data.LoadData();       
       }
}
