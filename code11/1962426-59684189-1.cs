    for(int i = 0; i < 2; i++)
    {
        int temp = i;
        var policy = Policy
            .Handle<Exception>()
            .RetryForeverAsync()
            .ExecuteAsync(async () => await Program.TaskMethod(temp.ToString()));
        policy_list.Add(policy);
    }
