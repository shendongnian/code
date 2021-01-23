    public IEnumerable<object> ViewModels
    {
       get
       {
          foreach (string name in Names)
          {
             switch (name)
             {
                case "Thing1":  yield return new Thing1ViewModel(name);
                case "Thing2":  yield return new Thing2ViewModel(name);
                default:  throw new InvalidOperationException();
             }
          }
       }
    }
