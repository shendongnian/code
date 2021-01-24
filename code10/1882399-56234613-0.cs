    if(firstCondition)
    {
       DoWork(attachments.Where(i => i.TestItemId == 1));
    }
    if(secondCondition)
    {
       DoWork(attachments.Where(i => i.TestItemId == 2));
    }
