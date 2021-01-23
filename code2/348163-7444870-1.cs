    [ServiceContract()]
    interface ITaskManager
    {
    	[OperationContract()]
    	MyCollection<Task> GetTaskByAssignedName(string name);
    }
    
    [DataContract()]
    [KnownType(typeof(DerivedTask))]
    class Task
    {
    
    }
    
    [DataContract()]
    class DerivedTask
    {
    
    }
