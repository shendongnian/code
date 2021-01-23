    [DefaultBindingProperty("ValueNoAnimation")]
    public class NoAnimationProgressBar : ProgressBar
    {
        /// <summary>
        /// Sets the progress bar value, without using 'Windows Aero' animation.
        /// This is to work around (hack) for a known WinForms issue where the progress bar 
        /// is slow to update. 
        /// </summary>
        public int ValueNoAnimation
        {
            get => Value;
            set
            {
                // To get around the progressive animation, we need to move the 
                // progress bar backwards.
                if (value != Maximum)
                    Value = value + 1; // Move past
                else
                {
                    // Special case as value can't be set greater than Maximum.
                    Maximum = value + 1;
                    Value = value + 1;
                    Maximum = value;
                }
                Value = value; // Move to correct value
            }
        }
    }
