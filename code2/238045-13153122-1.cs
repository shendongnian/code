    public class PhoneApplicationBasePage : PhoneApplicationPage
    {
    private object navParam = null;
    protected object Parameter{get;private set;}
    //use this function to start the navigation and send the object that you want to pass 
    //to the next page
    protected void Navigate(string url, object paramter = null)
     {    
       navParam = paramter;
       this.NavigationService.Navigate(new Uri(url, UriKind.Relative));
     }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
    //e.Content has the reference of the next created page
    if (e.Content is PhoneApplicationBasePage )
      {
       PhoneApplicationBasePage  page = e.Content as PhoneApplicationBasePage;
       if (page != null)
       { page.SendParameter(navParam); navParam=null;}
      }
    }
    private void SendParameter(object param)
    {
     if (this.Parameter == null)
      {
       this.Parameter = param;
       this.OnParameterReceived();
      }
    }
    protected virtual void OnParameterReceived()
    {
    //Override this method in you page. and access the **Parameter** property that
    // has the object sent from previous page
    }
    }
    
