            from r in replies
            group r by new { r.TopicId } into g
            select new
                {
                    TopicId = g.Key.TopicId, 
                    LastReply = g.Max(p => p.PostedDate)
                }
