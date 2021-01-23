    var tomorrow = DateTime.Today.AddDays(1);
            return from t in this.Events
                    where (t.StartTime >= DateTime.Today && t.StartTime < tomorrow && t.EndTime.HasValue)
                    select new
                    {
                        Client = t.Activity.Project.Customer.Name,
                        Project = t.Activity.Project.Name,
                        Task = t.Activity.Task.Name,
                        Rate = t.Activity.Rate.Name,
                        StartTime = t.StartTime,
                        EndTime = t.EndTime.Value,
                        Hours = t.EndTime.Value(t.StartTime.Subtract).Hours,
                        Description = t.Activity.Description
                    };
