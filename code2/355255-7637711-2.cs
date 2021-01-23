        private void button1_Click(object sender, EventArgs e)
        {
            string inputString = "Last Run: 2011-10-03 13:58:54 (7m 30s  ago) [status]";
            string replacementString = "Blah";
            string pattern = @"\((.+?)\s+ago\)";
            int backreferenceGroupNumber = 1;
            string outputString = Replace(inputString, replacementString, pattern, backreferenceGroupNumber);
            MessageBox.Show(outputString);
        }
        private string Replace(string inputString, string replacementString, string pattern, int backreferenceGroupNumber)
        {
            return inputString.Replace(Regex.Match(inputString, pattern).Groups[backreferenceGroupNumber].Value, replacementString);
        }
