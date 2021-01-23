    if String.IsNullOrEmpty(txtCounter.Value) {
       txtCounter.Value = "1";
    } else {
       int wCounter;
       wCounter = Convert.ToInt32(txtCounter.Value);
       if (wCounter >= 3) {
         Page.ClientScript.RegisterStartupScript(Page.GetType(), "Count Exceeded", "alert('The number of tries has been exceeded.');", True)
         
       } else {
         wCounter += 1;
         txtCounter.Value = wCounter.ToString();
       }
    }
