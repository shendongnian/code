    public interface IMainView
    {
       void MethodOnMainPage();
    }
    public class MainPage : IMainView
    {
    }
    public class MyClass 
    {
       private IMainView _view;
       public MyClass(IMainView view)
       {
          _view = view;
       }
       private void SomeEventHappened() 
       {
          _view.MethodOnMainPage();
       }
    }
