        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // This is the button labeled "Save" in the program.
                //
                File.WriteAllText("C:\\demo.txt", Tb_Admin.Text);
                File.WriteAllText("C:\\demo.txt", Tb_Name.Text);
                File.WriteAllText("C:\\demo.txt", Tb_Gender.Text);
            }
            catch(IoException ex)
            {
                //View the Output Window, copy the text to your question
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
