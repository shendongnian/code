    int result;
    if (!int.TryParse(subjectsLabel.Text, out result))
    {
     ShowAMessageToTheUser();
    }
    else
    {
     UseResult();
    }
