        private guaranteed = null;
        private List<NotificationsClass> notifications;
        public List<NotificationsClass> Notifications 
        {
            get 
            {
                 return notifications;
            }
            set
            {
                if(guaranteed != null)
                {
                    notifications = guranteed;
                    notifications.AddRange(value);
                    guaranteed = null
                 }
                 else
                    notifications = value;
            }
        
        }
    
    public MyClass () {
            guaranteed = notificationsGENERATEDList;
        }
