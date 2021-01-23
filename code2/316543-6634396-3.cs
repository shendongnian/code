        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            
            // Adding the tasks i want at App_Start 
            // so if the application restarted my task will refreshed.
            AddTask(ScheduledTasks.CleanGameRequests);
            AddTask(ScheduledTasks.CleanUpOnlineUsers);
        }
        // event to handel
        private static CacheItemRemovedCallback _onCacheRemove;
        private void AddTask(ScheduledTasks task)
        {
            _onCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
            HttpRuntime.Cache.Insert(task.ToString(), (int)task, null,
                DateTime.Now.AddSeconds((int)task), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, _onCacheRemove);
        }
        public void CacheItemRemoved(string key, object time, CacheItemRemovedReason r)
        {
            var task = (ScheduledTasks)Enum.Parse(typeof(ScheduledTasks), key);
            switch (task)
            {
                case ScheduledTasks.CleanGameRequests:
                    // Do the concept that you wanna to do.
                    GameRequest.CleanUp();
                    break;
                case ScheduledTasks.CleanUpOnlineUsers:
                    OnlineUsers.CleanUp();
                    break;
                default:
                    break;
            }
            
            // Don't forget to recreate the "CacheItem" again.
            AddTask(task);
        }
