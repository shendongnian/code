    class TimeSpanDecorator
	{
		protected TimeSpan timeSpan;
        public TimeSpanDecorator(TimeSpan ts)
        {
    		timeSpan = ts;
    	}
        public override string ToString() // return required TimeSpan view
	    {
            return timeSpan.Hours + ":" + timeSpan.Minutes;
        }
        public static TimeSpanDecorator Parse(String value) // parse entered value in any way you want
		{
    		String[] parts = value.Split(':');
    		if (parts.Length != 2)
                throw new ArgumentException("Wrong format");
            int hours = Int32.Parse(parts[0]);
            int minutes = Int32.Parse(parts[1]);
            TimeSpanDecorator result = new TimeSpanDecorator(new TimeSpan(hours, minutes, 0));
            if (result.timeSpan.Ticks < 0)
    		    throw new ArgumentException("You should provide positive time value");
            return result;
        }
        //other members
    }
    internal partial class MainForm : Form
    {
        (...)
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    	{
    		MessageBox.Show("Error occured: " + e.Exception.Message, "Warning!"); // showing generated argument exception
    		e.ThrowException = false; // telling form that we have processed the error
    	}
    }
