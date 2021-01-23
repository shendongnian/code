    class DataManager
    {
        // The lock on the operation.
        private readonly object lockObj = new object();
    
        // The state.
        private State theState = State.None;
    
        // The task to get the state.
        private Task<DataType> getDataTask;
    
        public DataType GetDataAsync()
        {        
           lock(lockObj)
           {
               if (theState == State.Getting)
                   return null;
               if (theState == State.Complete
                   return getDataTask.Result;
               
               // Set the state to getting.
               theState = State.Getting;
    
               // Start the task.
               getDataTask = Task.Factory.StartNew(() => {                     
                   // Get the data.
                   DataType result = DataFactory.GetData();
    
                   // Lock and set the state.
                   lock (lockObj)
                   {
                       // Set the state.
                       theState = State.Complete;
                   }
    
                   // Return the result.
                   return result;
               });
    
               // Return null to indicate the operation started
               // (is in "getting" state).
               return null;
           }
        }
    }
