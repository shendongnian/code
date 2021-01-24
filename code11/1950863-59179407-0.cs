    private void rollBtn_Click(object sender, RoutedEventArgs e)
    {
        if (Dicebtn1.IsEnabled) rndNum1 = rndNumbers.Next(1, 7); // max is exclusive !
        if (Dicebtn2.IsEnabled) rndNum2 = rndNumbers.Next(1, 7);
        if (Dicebtn3.IsEnabled) rndNum3 = rndNumbers.Next(1, 7);
        if (Dicebtn4.IsEnabled) rndNum4 = rndNumbers.Next(1, 7);
        if (Dicebtn5.IsEnabled) rndNum5 = rndNumbers.Next(1, 7);
        if (Dicebtn6.IsEnabled) rndNum6 = rndNumbers.Next(1, 7);
    }
