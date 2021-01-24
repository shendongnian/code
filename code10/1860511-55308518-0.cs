    if (activity.Type == ActivityTypes.Message)
    {
        if(active.Text == "send email")
        {
           await SendEmail();
        }
        else
        {
            //  other BasicBot.cs code
        }
    ...
