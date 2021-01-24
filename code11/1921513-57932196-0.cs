 if (number >= 7 && number <= 1)
Surely you meant...
 if (number >= 1 && number <= 7)
I can't tell precisely what sort of project you're working on, but the following slight modification works in wpf and should be all you need to solve this:
private void OKButton_Click(object sender, RoutedEventArgs e)
        {                      
            string day = myTextBox.Text.Trim();
            int number = 0;
            if (int.TryParse(day, out number))
            {
                if (number >= 1 && number <= 7)
                {
                    switch (day)
                    {
                        case "1":
                            dayOutputLabel.Content = "Sunday";
                            break;
                        case "2":
                            dayOutputLabel.Content = "Monday";
                            break;
                        case "3":
                            dayOutputLabel.Content = "Tuesday";
                            break;
                        case "4":
                            dayOutputLabel.Content = "Wednesday";
                            break;
                        case "5":
                            dayOutputLabel.Content = "Thursday";
                            break;
                        case "6":
                            dayOutputLabel.Content = "Friday";
                            break;
                        case "7":
                            dayOutputLabel.Content = "Saturday";
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid number input. Please use a number between 1 and 7.");
                }
