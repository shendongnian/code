    Task.WaitAll(
        listOfTasks.Select(
            item => Task.Factory.StartNew(() => 
            {
                DoSomeWork work = new DoSomeWork();
                work.CompleteTask();
            })
        ).ToArray()
    );
