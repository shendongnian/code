    private int _hour; // backing field
    private int Hour
        {
            get { return _hour; }
            set
            {
                //make sure hour is positive
                if (value < MIN_HOUR)
                {
                    _hour = 0;
                    MessageBox.Show("Hour value " + value.ToString() + " cannot be negative. Reset to " + MIN_HOUR.ToString(),
                    "Invalid Hour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //take the modulus to ensure always less than 24 hours
                    //works even if the value is already within range, or value equal to 24
                    _hour = value % MAX_HOUR;
                }
            }
        }
