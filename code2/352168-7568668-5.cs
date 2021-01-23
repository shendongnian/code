    //List<int> currentWorkingItem //contains the indices of the items in listview
    //List<string> URLsList //contains the URLs of the items in listview
    
    Parallel.ForEach(URLsList, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, (url, i, j) =>
    {
    
    //aborting
    if (!(bool)abortingItem[currentWorkingItem[(int)j]])
    {
        //show to user this link is currently being downloaded by highlighting the item to green...
        this.BeginInvoke((Action)(delegate()
        {
            //current working item 
            mylistview.Items[currentWorkingItem[(int)j]].BackColor = green;
    
        }));
    
        //here I download the contents of every link in the list...
        string HtmlResponse = GetPageResponse(url);
    
        //do further processing....
    }
    else
    {
      //aborted
    }
    });
