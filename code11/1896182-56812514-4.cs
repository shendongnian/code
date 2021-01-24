    async Task<IEnumerable<Insurance>> SearchAllByANI(string ani)
    {
        var tasks = new HashSet<Task<IEnumerable<Insurance>>>();
        var cts = new CancellationTokenSource();
        using (var Contexts = instContextfactory.GetContextList())
        {
            foreach (var context in Contexts.GetContextList())
            {
                tasks.Add(Task.Run(() =>
                {
                    return context.Insurance.GetInsuranceByANI(ani);
                }, cts.Token));
            }
        }
        while (tasks.Count > 0)
        {
            var task = await Task.WhenAny(tasks);
            var result = await task;
            if (result != null && result.Any())
            {
                cts.Cancel();
                return result;
            }
            tasks.Remove(task);
        }
        return null;
    }
