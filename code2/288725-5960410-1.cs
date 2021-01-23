    var description = new[]{"afds).", "afas.", /*...,*/ "aees."};
    var subTopic = new SubTopic { 
        Description  =  description,
        SubTopicId = Enumerable.Range(1, description.Length).ToArray()
    };
