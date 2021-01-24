    private void ManipulateBtn_Click(object sender, EventArgs e)
        {
            string input = InputTxt.Text; // Read the text from you Textbox in Windos form
            if (input == string.Empty)
            {
                return;
            }
            string temp = input[0].ToString(); // Create a temp for the first char(toString) from you input
            input = input.Remove(0,1); // Remove (from you input) At Index 0 (the idex from fist char in string) 1 time) 
            input += temp; //add the firs item from you input at the end of string
            InputTxt.Text = input; // prin the result in the Textbox back.
        }
