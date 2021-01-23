    internal class ProgramCounterTimerHandler
    {
        private int count = 0;
        private readonly Label label;
        internal ProgramCounterTimerHandler(Label label)
        {
            this.label = label;
        }
        internal void ShowProgramCount(object sender, EventArgs e)
        {
            count++;
            label.Text = string.Format("{0} {1} running", count,
                                       count == 1 ? "program" : "programs");
        }
    }
    Then you can use:
    timer.Tick += new ProgramCounterTimerHandler(label).ShowProgramCount;
