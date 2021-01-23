    public static IEnumerable<Task> WithOrdering(this IEnumerable<Task> source, TaskOrdering order)
    {
       switch (order)
       {
          case TaskOrdering.Name:
             return source.OrderBy(task => task.Name);
          case TaskOrdering.DueDate:
             return source.OrderByDescending(task => task.DueDate);       
       }
    }
