            System.Web.UI.Control ctl = root;
            var ctls = new LinkedList<System.Web.UI.Control>();
            if (root != null)
            {
                if (ctl.ID == id)
                    return ctl;
                foreach (System.Web.UI.Control child in ctl.Controls)
                {
                    if (child.ID == id)
                        return child;
                    if (child.HasControls())
                        GetControlIterativeClientID(child, id);                        
                }                
            }
            return null;
        }
