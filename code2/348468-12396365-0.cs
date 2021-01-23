    public static class FormGetUniqueNameExtention
    {
        public static string GetFullName(this Control control)
        {
            if(control.Parent == null) return control.Name;
            return control.Parent.GetFullName() + "." + control.Name;
        }
    }
