    Style myStyle = (Style)Application.Current.Resources["myStyleName"];
        
    public void SetDefaultStyle()
                {
                    if(Application.Current.Resources.Contains(typeof(TextBox)))
                        Application.Current.Resources.Remove(typeof(TextBox));
        
                    Application.Current.Resources.Add(typeof(TextBox),      
                        new Style() { TargetType = typeof(TextBox) });
                }
        
    public void SetCustomStyle()
                {
                    if (Application.Current.Resources.Contains(typeof(TextBox)))
                        Application.Current.Resources.Remove(typeof(TextBox));
        
                    Application.Current.Resources.Add(typeof(TextBox), 
                        myStyle);
                }
