    private void btnConvert_Click(object sender, EventArgs e)
    {
        decimal Input = Convert.ToDecimal(txtInput.Text); //grabs the input that the user entered
        // declare this outside the loop so you can use it later.
        decimal output = 0M;
        if (rbtnCelsius.Checked == true) //Test to see if the Celsius radio button is checked
        {
            output= ((Input - 32) * 5) / 9; //If yes, it uses this formula to convert the input from Farenheit to Celsius
            txtOutput.Text = Output.ToString(); //Outputs the message to the user, showing the Celsius end point
        }
        else //Says that the Celsius Radio Button is not checked, meaning that the Farenheit radio button is
        {
            output= (Input * 9) / 5 + 32; //Moves onto this formula, converts Celsius to Farenheit
            
        }
        txtOutput.Text =string.Format("{0} Celsius will is {1} Fahrenheit",input,output);
    }`
