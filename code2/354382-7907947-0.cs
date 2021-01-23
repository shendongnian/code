    public class ToolStripProgressBarC : ToolStripControlHost
    {
        // Call the base constructor passing in a MonthCalendar instance.
        public ToolStripProgressBarC() : base(new ProgressBar()) 
        {
            ((ProgressBar)Control).Style = ProgressBarStyle.Continuous;
        }
        public ProgressBar ProgressBarControl
        {
            get
            {
                return Control as ProgressBar;
            }
        }
        // Expose the ProgressBar.Value as a property.
        public int Value
        {
            get
            {
                return ProgressBarControl.Value;
            }
            set { ProgressBarControl.Value = value; }
        }
    }
