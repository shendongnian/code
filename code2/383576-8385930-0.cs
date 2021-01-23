    public class YourViewModel
    {
      private ObservableCollection<YourDataClass> yourColl;
      
      public void YourViewModel()
      {
        yourColl = new ObservableCollection<YourDataClass>();
        YourCollectionView = CollectionViewSource.GetDefaultView(yourColl);
        DisplayScale.ScalingChanged += () => YourCollectionView.Refresh();
      }
      
      var ICollectionView yourCollView;
      public ICollectionView YourCollectionView
      {
        get { yourCollView; }
        set {
          yourCollView = value;
          RaisePropertyChanged("YourCollectionView");
        }
      }
    }
