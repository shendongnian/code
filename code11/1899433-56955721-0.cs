            string line;
            string motcletest = SEARCH.Text;
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"D:\\TEST.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if ((line.Contains(motcletest)))
                    {
                        richTextBox1.Text = line.ToString();
                        file.ReadLine();//read first line after matching line
                        file.ReadLine();//read second line after matching line
                        line = file.ReadLine(); //third line that you are looking for
                        foreach(var value in line.Split(','))//split by ,
                        {
                           //Add the value the controls(textbox)
                           //if the count is not fixed, you might need to create a control and add it to a panel
                        }
                    }
                }
