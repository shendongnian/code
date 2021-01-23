        public static IEnumerable<T> GetControlList<T>(this ControlCollection controlCollection) where T : Control
        {
            foreach (Control control in controlCollection)
            {
                if (control is T)
                {
                    yield return (T)control;
                }
                if (control.HasControls())
                {
                    foreach (Control childControl in control.Controls.GetControlList<T>())
                    {
                        yield return childControl;
                    }
                }
            }
        }
 
