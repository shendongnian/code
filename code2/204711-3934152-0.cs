      public static System.Web.UI.Control FindControlIterative(System.Web.UI.Control root, string id)
        {
            System.Web.UI.Control ctl = root;
            var ctls = new LinkedList<System.Web.UI.Control>();
            while (ctl != null)
            {
                if (ctl.ID == id)
                    return ctl;
                foreach (System.Web.UI.Control child in ctl.Controls)
                {
                    if (child.ID == id)
                        return child;
                    if (child.HasControls())
                        ctls.AddLast(child);
                }
                if (ctls.First != null)
                {
                    ctl = ctls.First.Value;
                    ctls.Remove(ctl);
                }
                else return null;
            }
            return null;
        }
