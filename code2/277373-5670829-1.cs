    var q = (
       from C in db.tblComments
       where
          C.CategoryID == Category &&
          C.IdentifierID == Identifier
       join A in db.tblForumAuthors on C.UserID equals A.Author_ID
       // the following two lines are the left outer join thing. 
       join voteTemp in db.tblCommentVotes on voteTemp.CommentID equals C.ID into voteJoin
       from vote in voteJoin.DefaultIfEmpty()
       orderby C.PostDate descending
       group C by new { Comment = C, Username = A.Username } into g
       select new
       {
          g.Key.Comment,
          g.Key.Username,
          UpVotes = g.Count(x => x.UpVote),
          DownVotes = g.Count(x => !x.UpVote)
       }
    )
    .Skip(ToSkip > 0 ? ToSkip : 0)
    .Take(ToTake > 0 ? ToTake : int.MaxValue);
