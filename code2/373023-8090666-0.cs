    List<Type> customBoxes = new List<Type>();
    
    customBoxes.AddRange(new[] { typeof(PhoneBox), typeof(DigitBox), ....." });
    
    foreach (Control c in this.Controls)
    {
      if (customBoxes.Contains(c.GetType()))
      {
        c.Text = string.Empty;
      }
    }
