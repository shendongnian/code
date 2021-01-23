    public CommentsViewModel GetViewModel()
    {
        var attachments = 
            (from a in ar.Attachments 
            select new { id = a.Id, filename = a.FileName }).ToArray(); 
        var result = new CommentsViewModel
                {
                    comments = "Some string",
                    attachments = attachments
                };
    
        return result;
    }
