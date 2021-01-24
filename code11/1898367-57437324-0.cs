    internal class localized_OptionAttribute : OptionAttribute
    {
      public localized_Option ( string ResourceName )
        : base ( <root namespace>.Properties.Resources.ResourceManager.GetString ( ResourceName ) )
      {
      }
    }
