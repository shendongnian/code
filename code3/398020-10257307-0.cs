    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;
            if (e.Cancelled)
            {
                //write your code here
            }
            if (e.Error != null)
            {
                //write your code here
            }
            else //mail sent
            {
                //write your code here
            }
            mailSent = true;
        }
