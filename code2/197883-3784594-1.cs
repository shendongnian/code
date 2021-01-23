      Dictionary<FrameworkElement, DependencyProperty> savedElements = new Dictionary<FrameworkElement, DependencyProperty>();
    
    public Window_Load(object sender, EventArgs e) {
               savedElements.Add(firstNameText, TextBox.TextProperty);
                    savedElements.Add(lastNameText, TextBox.TextProperty);
            
                SettingsManager.LoadSettings(this, savedElements);
    }
    
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                SettingsManager.SaveSettings(this, savedElements);
            }
