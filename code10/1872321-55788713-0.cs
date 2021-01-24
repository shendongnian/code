    private void button1_Click(object sender, EventArgs e)
        {
            string[] A = { "Mathew", "Mark", "Luke", "John" };
            string[] B = { "Peter", "Mark", "Paul", "John" };
            
            List<string> Mismatch = new List<string>();
            List<string> Matched=new List<string>();
            if (A.Length != B.Length) { return; }
            int i;
            for (i =0; i < A.Length; i++)
            {
                if (A[i] == B[i])
                { Matched.Add($"A and B match with {A[i]} at position {i}"); }
                else
                { Mismatch.Add($"Mismatch at position {i} A contains {A[i]} B contains {B[i]}"); }
            }
            int correct = Matched.Count;
            int incorrect = Mismatch.Count;
            MessageBox.Show($"The number of correct is {correct}{Environment.NewLine}The number of incorrect is {incorrect}");
            label1.Text = String.Join(Environment.NewLine, Mismatch);
            label4.Text = String.Join(Environment.NewLine, Matched);
        }
