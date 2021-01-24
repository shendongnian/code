        private void Form1_Load(object sender, EventArgs e)
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
                    {
                        "January",
                        "February",
                        "March",
                        "April",
                        "May",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                    });
            txtTo.AutoCompleteCustomSource = source;
            txtTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
