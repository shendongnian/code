    int parsed;
    if (int.TryParse(mytextbox.Text, out parsed))
    {
        int result = parsed + 2;
        string add = result.ToString();
        // Use add here    
    }
    else
    {
        // Indicate failure to the user; prompt them to enter an integer.
    }
