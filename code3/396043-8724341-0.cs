    int currentIndex = 0;
    List<myObject> lst = getList();
    executor.BeginAsyncTask(lst[currentIndex], AsyncTaskCallBack)
    function AsyncTaskCallBack(result)
    {
       if(result.IsOK)
       {
          currentIndex+=1;
          if(currentIndex < lst.Count)
             executor.BeginAsyncTask(lst[currentIndex], AsyncTaskCallBack)
       }
    }
