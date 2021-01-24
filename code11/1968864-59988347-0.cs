    public class ShareDataEvent 
    {
      public delegate void IFormEventHandler(IForm sender);
      public IFormEventHandler ShareData [get; set;}
    
    }
    
    public class FormB : IForm 
    {
      public override void OnInitialize()
      {
        base.OnInitializeComponent();
        var shareDateEvent = new ShareDataEvent();
        ShareFormDataEvent.Instance[_thisForm.UniqueID] = 
        shareDataEvent; // First I add my new instance of ShareDataEvent class to the dictionary
        ShareFormDataEvent.Instance[ShareDataEvent].ShareData += new IFormEventHandler(ReceivingFormData); // Then I acces to that instance and attach the handler to the event.
        
      }
    }  
  
