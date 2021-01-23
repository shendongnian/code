     public static Control FindControlRecursive(Control ctlRoot, string sControlId)
        {
            // if this control is the one we are looking for, break from the recursion    
            // and return the control.    
            if (ctlRoot.ID == sControlId)
            {
                return ctlRoot;
            }
            // loop the child controls of this parent control and call recursively.    
            foreach (Control ctl in ctlRoot.Controls)
            {
                Control ctlFound = FindControlRecursive(ctl, sControlId);
                // if we found the control, return it.        
                if (ctlFound != null)
                {
                    return ctlFound;
                }
            }// we never found the control so just return null.    
            return null;
        }
