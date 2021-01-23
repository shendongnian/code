    var commentsCount = sqlReader["Comments"];
    if (commentsCount is DBNull)
    {
        objStreamItem.Comments = null; // this is a change from your example, but why use 0 if the property is nullable?
        listComments = null;
    }
    else
    {
        objStreamItem.Comments = (int)commentsCount;
        listComments = Comment.GetAll(objStreamItem.Id);
    }
