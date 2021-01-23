    public static class MyExensions
    {
        public static Control FindControlRecursively(this Control control, string name)
        {
            Control result = null;
            if (control.ID.Equals(name))
            {
                result = control;
            }
            else
            {
                for (var i = 0; i < control.Controls.Count; i++)
                {
                    result = control.Controls[i].FindControlRecursively(name);
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }
        public static T FindControlRecursively<T>(this Control control, string name)
            where T : Control
        {
            return control.FindControlRecursively(name) as T;
        }
    }
