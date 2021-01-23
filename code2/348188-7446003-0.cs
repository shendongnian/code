    List<CategoryModel> list =
        (from category in context.GetEvents(date, date) // Stored Procedure
            group category by category.CategoryId 
            into groupedByCategory // Group by Category
            select new CategoryModel
            {
                CategoryId = groupedByCategory.Key,
                Events = new ObservableCollection<EventModel>
                (
                    from evt in groupedByCategory
                    group evt by new { evt.EventId, evt.AssignedUserId, evt.EventName, evt.EventDescription, evt.IsRecurring } 
                    into groupedByEvent // Sub-Group for Events
                    select new EventModel
                    {
                        EventId = groupedByCategory.Key,
                        AssignedUserId = groupedByEvent.Key.AssignedUserId,
                        EventDescription = groupedByEvent.Key.EventDescription,
                        EventName = groupedByEvent.Key.EventName,
                        IsRecurring = groupedByEvent.Key.IsRecurring,
                        Instances = new ObservableCollection<EventInstanceModel>
                            (
                                from item in groupedByEvent
                                    select new EventInstanceModel
                                    {
                                        CompletedDate = item.CompletedDate,
                                        CompletedUserId = item.CompletedUserId,
                                        DueDate = item.DueDate,
                                        EventInstanceId = item.EventInstanceId,
                                        IsSkipped = item.IsSkipped.GetValueOrDefault()
                                    }
                            )
                    }
                )
            }
        ).ToList();
