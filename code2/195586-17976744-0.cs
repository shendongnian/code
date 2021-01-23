    public static void WriteToTextBox(string message)
    {
        TextBox myLog = (TextBox)CITX12Parser.Main.ActiveForm.Controls.Find("txtLog", true).First();
        myLog.Text = message;
    }
