    private bool _settingValue = false;
    
    void valueChanged(object sender, ...)
    {
       if (! settingValue)
       {
            _settingValue = true;
            try 
            { ... 
            }
            finally { settingvalue = false; }
       }
    }
