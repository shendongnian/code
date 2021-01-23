    var amountButtonString = enterAmountButton.Content as string;
            var enterTipButtonString = enterTipButton.Content as string;
            if (String.IsNullOrEmpty(amountButtonString))
                MessageBox.Show("Please enter the total bill amount.");
            else if (String.IsNullOrEmpty(enterTipButtonString))
                MessageBox.Show("Please enter the tip % amount.");  
