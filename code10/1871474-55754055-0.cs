        private void Calculate_Salary_Click(object sender, EventArgs e)
        {
            string MyNo= textBox1.Text ;
            string[] SplitedMyNo = MyNo .Split('/');
            int N1 = int.Parse(SplitedMyNo[0]);
            int N2 = int.Parse(SplitedMyNo[1]);
            int Res = N1 + N2;
            MessageBox.Show( Res.ToString() ) ;
                 }
