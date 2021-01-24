    using System;
    
    public class MainClass {
      public static void Main (string[] args) {
        ViewModel m = new ViewModel();
        View v = new View();
        v.Model = m;
        m.MakeSomeChange();
      }
    }
    
    public class View {
      private IViewModel _model;
      public IViewModel Model {
        get {
          return _model;
        }
        set {
          if(_model != null) {
            _model.OnChanged -= OnChanged;
          }
          if(value != null) {
            value.OnChanged += OnChanged;
          }
          _model = value;
        }
      }
      private void OnChanged(){
        //update view
        Console.WriteLine ("View Updated");
      }
    }
    
    public delegate void ViewChangeDelegate();
    public interface IViewModel {
      event ViewChangeDelegate OnChanged;
    }
    
    public class ViewModel: IViewModel {
      public event ViewChangeDelegate OnChanged;
      public void MakeSomeChange() {
        //make some change in the view Model
        OnChanged.Invoke();
      }
    }
