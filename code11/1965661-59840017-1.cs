    var normalized = new Normalized();
    var normalizedQuestions = new List<NormalizedQuestion>();
    foreach (var record in deNormalizedData)
    {
        normalized.userid = record.userid;
        normalized.name = record.name;
        normalizedQuestions.Add(new NormalizedQuestion() { Question = record.Question, Question_no = record.Question_no });                    
    }
    normalized.questions = normalizedQuestions;
    Console.WriteLine(JsonConvert.SerializeObject(normalized));
