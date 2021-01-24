    Question question = new Question() { Content = "Some content", TopicId = 1 };
    Topic topic = dbContext.Topics.SingleOrDefault(x => x.Id == question.TopicId);
    if(topic != null)
    {
        topic.Questions.Add(question);
        dbContext.SaveChanges();
    }
