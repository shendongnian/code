        public static Control FindControl(this Control baseControl, string id, bool recurse) 
        {
            foreach (Control ctl in baseControl.Controls)
            {
                if (ctl.ID==id)
                {
                    return (ctl);
                }
                if (recurse && ctl.Controls.Count > 0)
                {
                    Control subCtl = ctl.FindControl(id,recurse);
                    if (subCtl != null)
                    {
                        return (subCtl);
                    }
                }
            }
            return (null);
        }
