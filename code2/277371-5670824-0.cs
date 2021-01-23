    db.tblComments.Where(c => c.CategoryID == Category && c.IdentifierID == Identifier)
                  .Join(db.tblForumAuthors, c => c.UserID, a => a.Author_ID,
                         (c, a) =>
                         new
                         {
                            CommentID = c,
                            AuthorName = a.UserName,
                            UpVotes = c.Join(db.tblCommentVotes, c => c.CommentID
                                                                 v => v.CommentID,
                                                                 (c, v) => v).Count(v => v.UpVote)
                            DownVotes = c.Join(db.tblCommentVotes, c => c.CommentID
                                                                  v => v.CommentID,
                                                                  (c, v) => v).Count(v => v.DownVote)
                         });
