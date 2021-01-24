    List<Response> DoTask(List<MyObject> list)
    {
        var groupedList = list.GroupBy(x => x.Url)
        var taskList = new List<Task<List<Response>>>();
    
        foreach(group in GroupList)
        {
            taskList.Add(CallService(group.ToList()))
        }
    
        Task.WaitAll(taskList.ToArray());
        return taskList.SelectMany(x => x.Result);
    }
    
    // This method would get service call of same urls only
    async Task<List<Response>> CallService(List<MyObject> list)
    {
        var responseList = new List<Response>();
    
        foreach(var item in list)
        {
            var response = new Response();
            response.Result =  await HttpServiceCall(MyObject object);
            response.UserId = item.UserId
            
            responseList.Add(response);
        }
    
        return responseList;
    }
    
    async Task<Response> HttpServiceCall(MyObject object)
    {
        //make service call
    }
