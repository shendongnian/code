    private void button1_Click(object sender, EventArgs e)
        {
            Int32 i;
            String name;
            Int32[] array_number = new int[100];
            name = "1 3  5  17   8    9    6";
            name = name.Replace(' ', 'x');
            char[] chr = name.ToCharArray();
            for (i = 0; i < name.Length; i++)
            {
                if ((chr[i] != 'x'))
                {
                    array_number[i] = Convert.ToInt32(chr[i].ToString());
                    MessageBox.Show(array_number[i].ToString());
                }
            }
        }
