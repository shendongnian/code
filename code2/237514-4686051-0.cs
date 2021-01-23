    IQueryable<TopicsViewModel> topicsViewModel = 
      (from x in topicRepository.Topics                                               
       from y in replyRepository.Replies                                               
       where y.TopicID == x.TopicID                                               
       orderby y.PostedDate descending                                               
       select new TopicsViewModel { Topic = x, LastReply = y }
      ).First(); 
