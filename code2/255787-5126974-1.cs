    public static class MyExtensions
    {
        public static Control FindControlWithName(this Control control, string aName)
        {
             if (control.Name == aName)
             {
                return control;
             }
             foreach(var ctrl in control.Controls)
             {
                 Control found = ctrl.FindControlWithName(aName);
                 if (found != null)
                     return found;
             }
             return null;
        }
    }
