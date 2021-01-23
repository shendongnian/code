    public List<Task> GetTasksByAssignedTo(Guid contactId, Func<Task, object> someOrder)
    {
        List<Task> tasks = dc.Tasks.Where(x => x.ContactId == contactId)
                                   .OrderBy(someOrder)
                                   .ToList();
        return tasks;
    }
