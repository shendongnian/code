    var q = (from User in db.tblForumAuthors
                where User.Username == Username
                select new
                {
                    User.Password,
                    User.Salt,
                    User.Username,
                    User.Author_ID,
                    User.User_code,
                    User.Active,
                    User.Login_attempt,
                    User.Last_visit,
                }).SingleOrDefault();
