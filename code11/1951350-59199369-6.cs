    public static class ControlHelper
        {        
            public static IEnumerable<Control> GetControls(this Control parentControl, Type childType, IEnumerable<string> childrenNames)
            {
                // Get all children controls from parent.
                IEnumerable<Control> controls = parentControl.Controls.Cast<Control>(); 
                // Return all controls that match the condition of the child type and any of the children names.
                return controls.SelectMany(ctl => GetControls(ctl, childType, childrenNames))
                    .Concat(controls)
                    .Where(ctl => ctl.GetType() == childType && childrenNames.Any(c => c.Equals(ctl.Name)));
            }
    
        }
