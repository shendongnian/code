    public List<Task> GetTasksByAssignedTo(Guid contactId, TaskOrdering order)
    {
        List<Task> tasks = dc.Tasks.Where(x => x.ContactId == contactId)
                                   .WithOrdering(order)
                                   .ToList();
        return tasks;
    }
