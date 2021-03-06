            private void button3_Click(object sender, EventArgs e)
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("youfilePath");
            string line = string.Empty;
            try
            {
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    this.listBox1.Items.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                //close the file
                sr.Close();
            }
        }
