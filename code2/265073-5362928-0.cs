      protected void Page_Load(object sender, System.EventArgs e)
      {
    
          // Create a Style object for the body of the page.
          Style bodyStyle = new Style();
    
          bodyStyle.ForeColor = System.Drawing.Color.Blue;
          bodyStyle.BackColor = System.Drawing.Color.LightGray;
    
          // Add the style rule named bodyStyle to the header 
          // of the current page. The rule is for the body HTML element.
          Page.Header.StyleSheet.CreateStyleRule(bodyStyle, null, "body");
    
          // Add the page title to the header element.
          Page.Header.Title = "HtmlHead Example"; 
    
      }
