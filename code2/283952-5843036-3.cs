    var languages = new[]
                        {
                            new {Language = "Danish", Priority = 1},
                            new {Language = "English", Priority = 2}
                        };
    var id = 1;
    var text = (from t in db.Texts.Where(t => t.TextId == id).AsEnumerable()
                join l in languages on t.Language equals l.Language
                orderby l.Priority
                select t).FirstOrDefault();
