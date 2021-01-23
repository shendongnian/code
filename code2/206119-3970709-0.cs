    private string statusText;
    public string StatusText
    {
      get { return this.statusText;}          
      set { this.statusText = value;
          toolStripStatusLabel1.Text = this.statusText; 
      }
    }
