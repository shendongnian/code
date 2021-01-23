    // --------------------------------------------------------------------
    private void m_SettingTemplate ()
    {
      // the online doc recommends to parse the template
      string xaml = 
        @"<ItemsPanelTemplate
              xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
              xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>
            <WrapPanel ItemWidth=""150"" MaxWidth=""150""/>
          </ItemsPanelTemplate>";
      // assigning the template
      oMyListView.ItemsPanel = ( System.Windows.Markup.XamlReader.Parse (xaml) as ItemsPanelTemplate );
      // fetching the WrapPanel
      WrapPanel oWrapPanel = m_WrapPanelAusVisualHolen (oMyListView);
      Debug.Assert (oWrapPanel != null);
      if ( oWrapPanel != null )
      { // adjusting the size of the WrapPanel to the ListView
        Binding oBinding = new Binding ("ActualWidth");
        oBinding.Source = oMyListView;
        oWrapPanel.SetBinding (WrapPanel.MaxWidthProperty, oBinding);
      };
    }
 
