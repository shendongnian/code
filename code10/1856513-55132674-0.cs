    private void Form1_Load(object sender, EventArgs e)
        {
            cbConversion.SelectedText = "Miles to Kilometers";
            string[] Conversion = new string[] { "Miles to Kilometers",
                "Kilometers to Miles",
                "Feet to Meters",
                "Meters to Feet",
                "Inches to Centimeters",
                "Centermeters to Inches" };
            { }
            for (int i = 0; i < Conversion.Length; i++)
            {
                cbConversion.Items.Add(Convert.ToString(Conversion[i]));
            }
            miles = 0m;
            kilometers = 0m;
            feet = 0m;
            meter = 0m;
            inches = 0m;
            centimeter = 0m;
            cbConversion.SelectedIndex = 0;
            
        }
             private void cbConversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            conversions = Convert.ToString(cbConversion.SelectedItem);
            IList<string> lstString = new List<string>();
            lstString.Add("Miles:");
            lstString.Add("Kilometers:");
            lstString.Add("Feet:");
            lstString.Add("Meters:");
            lstString.Add("Inches:");
            lstString.Add("Centimeters:");
            
            label2.Text = lstString[cbConversion.SelectedIndex];
            IList<string> lstStringTwo = new List<string>();
            lstStringTwo.Add("Kilometers:");
            lstStringTwo.Add("Miles:");
            lstStringTwo.Add("Meters:");
            lstStringTwo.Add("Feet:");
            lstStringTwo.Add("Centimeters:");
            lstStringTwo.Add("Inches:");
            label3.Text = lstStringTwo[cbConversion.SelectedIndex];
            
        }
        private void calculateConversions()
        {
            decimal input = Convert.ToDecimal(txtInput.Text);
            decimal mileToKM = Convert.ToDecimal(1.6093);
            decimal kMToMile = Convert.ToDecimal(0.6214);
            decimal ftToM = Convert.ToDecimal(0.3048);
            decimal mToFt = Convert.ToDecimal(3.2808);
            decimal inToCm = Convert.ToDecimal(2.54);
            decimal cmToIn = Convert.ToDecimal(0.3937);
            if (cbConversion.SelectedText.ToString() == "Miles to Kilometers")
            {
                decimal miles = (input * mileToKM);
                txtOutput.Text = miles.ToString();
            }
