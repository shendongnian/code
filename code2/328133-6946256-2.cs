    public void SetDefaultStyle()
    {
        if(this.Resources.Contains(typeof(TextBox))) 
            this.Resources.Remove(typeof(TextBox));
        this.Resources.Add(typeof(TextBox),      
            new Style() { TargetType = typeof(TextBox) });
    }
    public void SetCustomStyle()
    {   
        if(this.Resources.Contains(typeof(TextBox))) 
            this.Resources.Remove(typeof(TextBox));
        this.Resources.Add(typeof(TextBox), 
            myStyle);
    }
