    public class MyViewPage : ContentPage
    {
      MyVieModel ViewModel = null;
      public MyViewPage(){
        this.BindingContext = ViewModel = new MyViewModel();
      }
    }
