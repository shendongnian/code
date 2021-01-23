        private Control RecursiveControlFind(Control parent, string controlID)
        {
            Control child = parent.FindControl(controlID);
            if (child == null)
            {
                if (parent.Controls.Count > 0)
                {
                    foreach (Control nestedControl in parent.Controls)
                    {
                        child = RecursiveControlFind(nestedControl, controlID);
                        if (child != null)
                            break;
                    }
                }
            }
            return child;
        }
