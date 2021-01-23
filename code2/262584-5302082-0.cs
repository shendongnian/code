    var x = SchedulerMatrixStorage.Resources
                                  .Items
                                  .Select(ConvertColumnId)
                                  .ToList();
    private static long ConvertColumnId(object id)
    {
        // Do whatever it takes to convert `id` to a long here... for example:
        if (id is long)
        {
            return (long) id;
        }
        if (id is int)
        {
            return (int) id;
        }
        string stringId = id as string;
        if (stringId != null)
        {
            return long.Parse(stringId);
        }
        throw new ArgumentException("Don't know how to convert " + id +
                                    " to a long");
    }
