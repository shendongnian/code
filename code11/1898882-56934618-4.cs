      private void InputText_TextChanged(object sender, TextChangedEventArgs e) {
        if (string.IsNullOrEmpty(InputText.Text)) 
          OutputText.Clear();
        else {
          // You have to create the instance (checker)
          ICheckPalindrome checker = new PalindromeChecker(); 
          // IsPalindrome is the instance method; you can't call is as 
          // PalindromeChecker.IsPalindrome
          string suffix = checker.IsPalindrome(InputText.Text) 
            ? "is a palindrome"
            : "is NOT a palindrome";
          OutputText.Text = $"{InputText.Text} {suffix}";  
        }  
      } 
      
