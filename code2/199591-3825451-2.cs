    class PointCloud
    {
        public Point3DCollection Points { get; private set; }
        
        public event EventHandler AllThreadsCompleted;
    
        public PointCloud()
        {
            this.Points = new Point3DCollection(1000);
            var task1 = Task.Factory.StartNew(() => AddPoints(0, 0, 192));
            var task2 = Task.Factory.StartNew(() => AddPoints(1, 193, 384));
            var task3 = Task.Factory.StartNew(() => AddPoints(2, 385, 576));
            Task.Factory.ContinueWhenAll(
                new[] { task1, task2, task3 }, 
                OnAllTasksCompleted, // Call this method when all tasks finish.
                CancellationToken.None, 
                TaskContinuationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext()); // Finish on UI thread.
        }
    
        private void OnAllTasksCompleted(Task<List<Point3D>>[] completedTasks)
        {
            // Now that we've got our points, add them to our collection.
            foreach (var task in completedTasks)
            {
                task.Result.ForEach(point => this.points.Add(point));
            }
    
            // Raise the AllThreadsCompleted event.
            if (AllThreadsCompleted != null)
            {
                AllThreadsCompleted(this, EventArgs.Empty);
            }
        }
    
        private List<Point3D> AddPoints(int scanNum, int x, int y)
        {
           const int goodValue = 42;
           List<Point3D> result = new List<Point3D>(500);
           var points = from pointX in Enumerable.Range(0, x)
                        from pointY in Enumerable.Range(0, y)
                        let pointZ = FindZ(pointX, pointY)
                        where pointZ == goodValue
                        select new Point3D(pointX, pointX, pointZ);
           result.AddRange(points);
           return result;
        }
    }
