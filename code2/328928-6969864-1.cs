           using (var ctx = new myModel.myEntities())
            {
                int pollID = 1;
                var poll = (from p in ctx.Polls
                            where p.PollID == pollID
                            select p).FirstOrDefault();
                poll.Question = txtPoll.Text.Trim();
                ctx.SaveChanges();
            }
