    public static class FormUtility
    {
        /// <summary>
        /// Lock the form whilst processing
        /// </summary>
        /// <param name="controlCollection"></param>
        /// <param name="enabled"></param>
        public static void FormState(Control.ControlCollection controlCollection, bool enabled)
        {
            foreach (Control c in controlCollection)
            {
                c.Enabled = enabled;
                c.Invalidate();
                c.Refresh();
            }
        }
     }
