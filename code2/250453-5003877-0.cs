    //Create an instance of your Domain context in your class.
    YourDomainContext context = new YourDomainContext();
    if (context.HasChanges)
    {
        context.SubmitChanges(so =>
            {
                string errorMsg = (so.HasError) → "failed" : "succeeded";
                MessageBox.Show("Update " + errorMsg);
            }, null);
    }
    else
    {
        MessageBox.Show("You have not made any changes!");
    }
