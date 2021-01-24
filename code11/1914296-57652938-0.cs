    using System.Threading.Tasks;   
    static bool m_bFirstLanguageChangeNavigation = true;
    async private void Show_Click(object sender, RoutedEventArgs e)
    {
        var context = ResourceContext.GetForCurrentView();
        var selectedLanguage = MyComboBox.SelectedValue;
        var lang = new List<string>();
        lang.Add(selectedLanguage.ToString());
        ApplicationLanguages.PrimaryLanguageOverride = selectedLanguage.ToString();
        ResourceContext.GetForCurrentView().Reset();
        ResourceContext.GetForViewIndependentUse().Reset();
    
    
        //added to work the first time
       if (m_bFirstLanguageChangeNavigation)
        {
           m_bFirstLanguageChangeNavigation = false;
           await Task.Delay(100);
        }
    
    
        Frame.Navigate(this.GetType());               
    }
