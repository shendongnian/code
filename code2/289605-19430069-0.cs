    private void HandleOnChange(object sender, SqlNotificationEventArgs e)
    {
    ...
    
    var someType = e.Type; /*If it is Subscribe, not Change, then you may have your SQL statement wrong*/
    ...
    }
