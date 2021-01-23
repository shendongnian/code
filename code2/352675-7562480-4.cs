    System.Threading.Timer WorkItemTimer = new Timer((s) =>
        {
            var items = WorkItemRepository.GetItemList(); //database call
            foreach (var item in items)
            {
                WorkItems.Add(item);
            }
        }, null, 30000, 30000);
