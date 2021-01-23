    public class MyUserControl : UserControl
    {    
        public IService Service { get; set; }
    
        public MyUserControl()
        {
           Service = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IService>();
           // You can do something with Service here already.
        }
    }
