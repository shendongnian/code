    public class MyPage : TabbedPage
    {
      public MyPage() 
      {
    
        this.Children.Add(new Page1());
        this.Children.Add(new Page2());
    
        if (some conditional check based on user) 
        {
          this.Children.Add(new Page3());
        }
    
      }
    }
