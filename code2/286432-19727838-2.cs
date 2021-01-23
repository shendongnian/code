    // Get dpi width
    
     float x = this.CreateGraphics().DpiX;
    
    // if screen is width
    
    if (x == 120)
    
    // Get big image from Resources
    
    this.BackgroundImage = Properties.Resources.BigImage;
    
    else if (x==96)
    {
           // Get small image from Resources
           this.BackgroundImage = Properties.Resources.loading49;
           
           this.BackColor = ColorTranslator.FromHtml("#E6E6E6");
           this.button2.Size = new Size(85, 30);
           this.button1.Size = new Size(75, 24);
           this.textBox1.Size = new Size(150, 40);
               
    }
