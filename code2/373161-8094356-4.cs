    if (!Regex.IsMatch(txtFirstName.Text, @"^(\w)+$"))
    {
        // Define a class in your style sheet that looks like
        txtFirstName.CssClass = "yellowBox";
        
        // Obviously you have a lblError control, but is
        // that control visible? If not you must change its
        // visibility. This should be done after all of the
        // processing blocks are complete.
        lblError.Text += "Please enter first name<br />";
    }
    if ( ... next condition ... )
    {
        ... 1, 2, skip a few ...
    }
    // If you've appended something to the lblError
    // then make it visible.
    if (lblError.Text.Trim().Length > 0) 
        lblError.Visible = true;
