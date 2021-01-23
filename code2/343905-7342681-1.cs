    if (Session.Item["voted"] == "1")
    {
        Label lblMessageToDisplay = new Label();
        lblMessageToDisplay.Text = "Thanks for your vote";
        placeHolder1.Controls.Add(lblMessageToDisplay);
    }
    else
    {
        LinkButton registrationLink = new LinkButton();
        registrationLink.Text = "Please Register";
        registrationLink.PostBackUrl = "register.aspx";
        placeHolder1.Controls.Add(registrationLink);
    }
