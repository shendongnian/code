    private async void btnAction_Click(object sender, RoutedEventArgs e)
    {
       btnAction.IsEnabled = false;
       txtResult.Text = "";       
       lblStatus.Text = "Wait...";
    
       string input = query.Text;
    
       // calling a method that takes a long time (>3s) to finish and return
       var attempt =  await Task.Run(() => someLibrary.doSomethingWith(input));
    
       if (attempt.ContainsKey("success"))
       {
          if (attempt["success"] == true)
          {
             txtResult.Text = "Success! The door is: " + (attempt["is_open"] ? "open" : "closed");
             lblStatus.Text = "";
          }
          else
          {
             lblStatus.Text = "Error! The service says: " + attempt["errorMessage"];
          }
       }  
       else
       {
          MessageBox.Show("There was a problem getting results from web service.");
          lblStatus.Text = "";
       }
       btnAction.IsEnabled = true;
    
    }
