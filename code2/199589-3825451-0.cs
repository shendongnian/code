    class PointCloud
    {
        private Point3DCollection points = new Point3DCollection(1000);
        
        public event EventHandler AllThreadsCompleted;
    
        public PointCloud()
        {
            var task1 = Task.Factory.StartNew(() => AddPoints(0, 0, 192));
            var task2 = Task.Factory.StartNew(() => AddPoints(1, 193, 384));
            var task3 = Task.Factory.StartNew(() => AddPoints(1, 193, 384));
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
            List<Point3D> result = new List<Point3D>();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var z = 42;
                    //z = FindZ(x, y);
                    System.Threading.Thread.Sleep((int)(2000 * new Random().NextDouble()));
    
                    if (z == 42)
                    {
                        result.Add(new Point3D(x, y, z));
                    }
                }
            }
            return result;
        }
    }
