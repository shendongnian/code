            private string lastMoveResult = string.Empty;
            private string lastGeniusResult = string.Empty;
 
            private void submit_Click(object sender, RoutedEventArgs e)
            {
                if (((String)submit.Content) == "Submit")
                {
                    lastMoveResult = Move();
                    submit.Content = "Wait for Genius...";
                    uReload.IsEnabled = false;
                    uFire.IsEnabled = false;
                    uShield.IsEnabled = false;
                    lastGeniusResult = Genius();
                }
                else if (((String)submit.Content) == "Go!")
                {
                    GeniusSpeak.Text = "";
                    OutcomeDesc.Text = "You have " + lastMoveResult + " and Genius has " + lastGeniusResult ;
                    Outcome.Text = "ANOTHER ROUND...";
                    submit.Content = "Continue";
                }
   
