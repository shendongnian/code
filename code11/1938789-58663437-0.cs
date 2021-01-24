    public void Run(string[] list, Func<IQueryable, IQuerayble> action)
    {
        if (!Utils.IsNullOrEmpty(list))
        {
            foreach (var listenManageRuleNames in list)
            {
                 var query = eventHub.Update();
                 query = action(query); 
                 await query.ApplyAsync();
            }
        }
    }
