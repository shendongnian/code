        string search = "My is";
        var arr = search.Split(' ');
        List<QuestionTb1> query = new List<QuestionTb1>();
        foreach (var word in arr)
        {
            var newQuestionTb1s = _db.QuestionTb1.Where(a => a.questionTitle.Contains(word)).Except(query).ToList();
            query.AddRange(newQuestionTb1s);
        }
