    //TODO: your routine which tests for palindrome
    private static bool IsPalindrome(string value) 
    {
        ...
    }
    
    private void InputText_TextChanged(object sender, TextChangedEventArgs e)
    {
        // This event handler runs when user changes text in InputText
        // i.e. inout anything into InputText 
        // We should:
    
        // 1. Obtain user input
        string value = InputText.Text;
    
        // 2. Check for being palindrome
        bool isPalindrome = IsPalindrome(value); 
    
        // 3. Output results into OutputText
        OutputText.Text = value + (isPalindrome ? " is a palindrome" : " is NOT a palindrome");   
    }
