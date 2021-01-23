    app.PostCompleted += delegate (o, args)
    {
        if (args.Error == null)
        {
            MessageBox.Show("Picture posted to wall successfully.");
        }
        else
        {
            MessageBox.Show(args.Error.Message);
        }
    };
