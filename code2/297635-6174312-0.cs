    public class ItemVM : INotifyPropertyChanged // if you want runtime changes to be reflected in the UI
    {
      public string Text {... raise property change in setter }
      public Color BackgroundColor {... ditto... }
    }
