`
        public Regex FilterNormaal = new Regex(@"[A-Z]{2}(\d)+B?\d*");
        private void BtnUitlezen_Click(object sender, EventArgs e)
        {
            RtBEditor.Clear();
            /*
             Temp dummy vatcodes for initial testing.
             */
            Form1.Dummy1.VAT = "NL855291886B01";
            Form1.Dummy2.VAT = "DE483270846";
            Form1.Dummy3.VAT = "SE482167803501";
            OCR Reader = new OCR();
            /*
             Grab and process image
             */
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Input = new Bitmap(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("Please open an image file.");
                }
            }
            string[] ProcessedFile = Reader.ProcessFile(Input);
            foreach(string S in ProcessedFile)
            {
                string X = S.Replace(" ", string.Empty);
                RtBEditor.AppendText(X + "\n");
            }
            foreach (Match M in FilterNormaal.Matches(RtBEditor.Text))
            {
                MessageBox.Show(M.Value);
            }    
}
`
At first, I attempted to iterate through my array of strings to find a match, but for reasons unknown, this did not yield any results. When applying the regex to the entire textbox, it did output the results I needed.
