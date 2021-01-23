    protected void CommentsItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var commentItem = (Comment)(((ListViewDataItem)e.Item).DataItem);
        var commentControl = (Comment)e.Item.FindControl("CommentControl");
        commentControl.CommentItem = commentItem;
    }
