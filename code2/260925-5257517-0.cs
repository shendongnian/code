        [Test]
        public void CompositeDictionary()
        {
            
            //Create a dictionary of periods
            IList<PeriodHolder> periodHolders = new List<PeriodHolder>();
            periodHolders.Add(new PeriodHolder("Type1", "06:00", "14:00"));
            periodHolders.Add(new PeriodHolder("Type2", "14:01", "22:00"));
            periodHolders.Add(new PeriodHolder("Type3", "22:01", "05:59"));
            //Create the test combobox in a test form
            Form testForm = new Form();
            ComboBox testComoBox = new ComboBox();
            testForm.Controls.Add(testComoBox);
            testComoBox.DataSource = periodHolders;
            testComoBox.ValueMember = "PeriodName"; //The name of the Name property in PeriodHolder
            testComoBox.DisplayMember = "PeriodString"; //The name of the PeriodString property in PeriodHolder
            testComoBox.SelectedIndex = 1;
            
            string selectedType = testComoBox.ValueMember[testComoBox.SelectedIndex].ToString(); //Get the type so you can lookup in dictionary
            foreach (PeriodHolder periodHolder in periodHolders)
            {
                if (periodHolder.PeriodName == selectedType)
                {
                    //Use period holder for whatever you need
                    string fromTime = periodHolder.TimeFrom; //Extract fromTime from periodholder
                    string toTime = periodHolder.TimeTo;     //Extract toTime from periodholder
                    Console.WriteLine(periodHolder.PeriodString);
                    break; //you've found it -- Don't look anymore
                }
            }
            
        }
        public class PeriodHolder
        {
            public PeriodHolder(string name, string from, string to)
            {
                PeriodName= name;
                TimeFrom =from;
                TimeTo = to;
            }
            public string PeriodName { get; set; }
            public string TimeFrom { get; set; }
            public string TimeTo { get; set; }
            public string PeriodString
            {
                get
                {
                    return TimeFrom + " - " + TimeFrom;
                }
            }
        }
