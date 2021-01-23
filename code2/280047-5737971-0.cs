        public static Control FindControlRecursively(Control parent, string id)
        {
            Control control = parent.FindControl(id);
            if (control != null)
            {
                return control;
            }
            else
            {
                foreach (Control childControl in parent.Controls)
                {
                    control = FindControlRecursively(childControl, id);
                    if (control != null)
                    {
                        return control;
                    }
                }
            }
            return null;
        }
