    private void FindComponentByName(string aName)  
    {  
        Control c = FindComponentByName(this);
        if (c != null)
        {
            dosomething();
        }
    }
    private Control FindComponentByName(Control c, string aName)  
    {
       if (c.Name == aName)
       {
           return c;
       }
       foreach(var control in c.Controls)  
       {  
          //recurse into containers controls to make sure we visit all depths
          Control found = ctrl.FindComponentByName(control, aName);
          if (found != null)
               return found;
       }
       return null;
    }
