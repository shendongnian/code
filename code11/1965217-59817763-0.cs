foreach (file in files)
{
    ReadTheFileAndComputeAFewThings(file);
    CallAWebService(file);
    MakeAFewDbCalls(file);
}
orginal + async (beter than above, depending!)
foreach (file in files)
{
   await ReadTheFileAndComputeAFewThings(file);
   await CallAWebService(file);
   await MakeAFewDbCalls(file);
}
This will not be better if the calls are not actually implementing async, then it will be worse.
Another way this will be worse is if the async-ness is so short they it out weight the cost of Task.
Each async Task, creates a managed thread, which reverse 1mb from system, and add thread syncing time.
Altho the  syncing is extremely low if this is done in a tight loop it will see performance issues.
Key here is the Task must actually be the async versions. 
 - SaveChanges vs SaveChangesAscync 
	
 - Read vs ReadAscync
Parallel (better than above, depending!)
Parallel.ForEach(files, item) 
{
	ReadTheFileAndComputeAFewThings(item);
    CallAWebService(item);
    MakeAFewDbCalls(item);
}
if this can all happen at the same time, then this is better.
 Not better if the methods are not thread safe.
Parallel + async  (beter than above, depending!)
Parallel.ForEach(files, item) 
{
   await ReadTheFileAndComputeAFewThings(item);
   await CallAWebService(item);
   await MakeAFewDbCalls(item);
}
**FYI - Parallel + async example above is actually incorrect!!!**
As the Parallel.ForEach itself is not async, you will need to do some research as to how to build a async version of Parallel.ForEach
Aslo the same comments above apply when using in conjunction.
