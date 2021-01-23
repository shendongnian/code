      public void SetDefaultStyle()
        {
            this.Resources.Add(typeof(TextBox), new Style() { TargetType = typeof(TextBox) });
        }
    
        public void SetCustomStyle()
        {   
            this.Resources.Add(typeof(TextBox), myStyle);
        }
