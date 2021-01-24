    FirebaseDatabase.DefaultInstance.GetReference("Timestamp").RunTransaction(mutableData =>
    {
        mutableData.Value = ServerValue.Timestamp;
        return TransactionResult.Success(mutableData);
    })
    .ContinueWith(task => 
    {
        long currentTimestamp = (long)(task.Result.Value);
        //Use this timestamp in the next step
    });
