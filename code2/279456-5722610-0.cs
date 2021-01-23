    //Doesn't have to be a button click...just an example.
     private void button1_Click(object sender, EventArgs e)
        {
            int[] str = new int[4] { 1, 2, 3, 4 };
            int result = Sum(str);
            MessageBox.Show(result.ToString());
        }
        int Sum(int[] values)
        {
            int sum= 0;
            for (int i = 0; i < values.Length; ++i)
            {
                sum += values[i];
            }
            return sum;
        }
