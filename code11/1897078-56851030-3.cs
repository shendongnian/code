    //TODO: your routine which tests for palindrome
    private static bool IsPalindrome(string value) 
    {
        ...
    }
    
    private void InputText_TextChanged(object sender, TextChangedEventArgs e)
    {
        // This event handler runs when user changes text in InputText
        // i.e. input anything into InputText 
        // We should:
    
        // 1. Obtain user input
        string word = InputText.Text;
    
        // 2. Check for being palindrome
        bool isPalindrome = IsPalindrome(word); 
    
        // 3. Output results into OutputText
        OutputText.Text = word + (isPalindrome ? " is a palindrome" : " is NOT a palindrome");
    }
