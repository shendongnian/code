        for (int n = 1; n <= wordComments.Count; n++)
        {
            Word.Comment comment = this.wordDoc.Comments[n];
            Word.Range range = this.wordDoc.Range(comment.Scope.Start, comment.Scope.End);
            String commentText = comment.Range.Text;
            this.wordDoc.Application.ActiveDocument.Bookmarks.Add("BOOKMARK"+n, range);
        }
