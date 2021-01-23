    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        DoAsyncWork(()=>{
            //continue here
        });
                    
    }
    private void DoAsyncWork(Action finishedCallback)
    {
        //Doing some async work, and in the end of the last async call, 
        //a global List<string> myList is filled
        //at this point call:
        //finishedCallback();
    }
