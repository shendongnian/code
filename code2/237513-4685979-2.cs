                    List<TopicsViewModel> topicsViewModelList = new List<TopicsViewModel>();
                    foreach (Topic topic in topics)
                    {
                        Reply lastReply = replyRepository.GetRepliesBy_TopicID(topic.TopicID).OrderBy(x => x.PostedDate).LastOrDefault();
    
                        topicsViewModelList.Add(new TopicsViewModel
                        {
                            Topic = topic,
                            LastReply = lastReply
                        });
                    }
