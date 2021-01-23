    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
    
            cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED  
            
            if (this.IsXpOr2003 == true)
                cp.ExStyle |= 0x00080000;  // Turn on WS_EX_LAYERED
                    
            return cp;
        }
    }
    
    private Boolean IsXpOr2003
    {
       get
       {
           OperatingSystem os = Environment.OSVersion;
           Version vs = os.Version;
    
           if (os.Platform == PlatformID.Win32NT)
               if ((vs.Major == 5) && (vs.Minor != 0))
                   return true;
               else
                   return false;
           else
               return false;
        }
    }
