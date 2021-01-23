    public foo()
    {
      var a = new HyperLink()
          { 
              Text="Test", 
              NavigateUrl=VirtualPathUtility.ToAbsolute("~/abc.aspx")
          };
      this.Controls.Add(a);
    }
