    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace AppName
    {
        public static class ControlExtensions
        {
            public static IEnumerable<Control> GetAllCtls(this Control control, Type type)
            {
                var controls = control.Controls.Cast<Control>();
    
                return controls.SelectMany(ctrl => GetAllCtls(ctrl, type))
                                          .Concat(controls)
                                          .Where(c => c.GetType() == type);
            }
        }
    }
