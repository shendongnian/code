        private string[] arrDates = new string[10000];
        protected void Page_Load(object sender, EventArgs e)
        {
            initialise();
            RunRegexDemo();
            RunDateTimeParseDemo();
        }
        private void initialise()
        {
            Random ryear, rmonth, rdate;
            ryear = new Random();
            rmonth = new Random();
            rdate = new Random();
            int y, m, d;
            
            DateTime dt;
            for (int i = 0; i < arrDates.Length; i++)
            {
                y = 0;
                m = 0;
                d = 0;
                while (y < 1850)
                {
                    y = ryear.Next(2050);
                }
                while (m < 1 || m > 12)
                {
                    m = rmonth.Next(12);
                }
                while (d < 1 || d > 28)
                {
                    d = rdate.Next(28);
                }
                dt = new DateTime(y, m, d);
                arrDates[i] = dt.ToString("yyyy-MM-dd");
                //lbl1.Text += "<br />" + arrDates[i];
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
        }
        private void RunRegexDemo()
        {
            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
            lbl1.Text+= "<h4>Starting Regex demo</h4>";
            string f;
            st.Start();
            
            foreach(string x in arrDates){
                f= "<br/>" + x + " is a valid date? = " + System.Text.RegularExpressions.Regex.IsMatch(x, @"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$");
            }
            st.Stop();
            lbl1.Text+= "<p>Ended RegEx demo. Elapsed time: " + st.ElapsedMilliseconds;
        }
        protected void RunDateTimeParseDemo(){
            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
            lbl1.Text += "<h4>Starting DateTime.Parse demo</h4>";
            st.Start();
            DateTime dt;
            string f;
            foreach (string x in arrDates)
            {
                f = "<br/>" + x + " is a valid date? = " + DateTime.TryParse(x, out dt);
            }
            st.Stop();
            lbl1.Text += "<p>Ended TryParse demo. Elapsed time: " + st.ElapsedMilliseconds;
        }
