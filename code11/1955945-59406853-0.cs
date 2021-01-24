    public abstract class CardBase<TData> : UserControl, IView<TData>, ICardBase where TData : VMCardBase
    {
      public CardBase()
      {
        this.Initialized += CardBase_Initialized;
    
        this.DataContext = DesignerProperties.GetIsInDesignMode(this)
          ? new DesignModeViewModel()
          : new ViewModel();
       }
    }
