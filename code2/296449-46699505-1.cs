    public ViewModel : ReactiveObject
    {
      private ReactiveList<EffectStyleLookup> _effectStyles;
      public ReactiveList<EffectStyleLookup> EffectStyles
      {
        get { return _effectStyles; }
        set { this.RaiseAndSetIfChanged(ref _effectStyles, value); }
      }
    
      // See below for more on this
      private EffectStyle _selectedEffectStyle;
      public EffectStyle SelectedEffectStyle
      {
        get { return _selectedEffectStyle; }
        set { this.RaiseAndSetIfChanged(ref _selectedEffectStyle, value); }
      }
    
      public ViewModel() 
      {
        // Convert a list of enums into a ReactiveList
        var list = (IList<EffectStyle>)Enum.GetValues(typeof(EffectStyle))
          .Select( x => new EffectStyleLookup() { 
            Item = x, 
            Display = x.ToString()
          });
          
        EffectStyles = new ReactiveList<EffectStyle>( list );
      }
    }
