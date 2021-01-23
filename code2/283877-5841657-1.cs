    try {
    // Update Code Here
    }
    catch (Exception e) {
    // Error message in e.Message
    // On a form
       MessageBox.Show(e.Message, "Error!");
    // TextBox text1 is defined
       text1.Text = e.Message;
       System.Console.WriteLine(e.Message);
    }
