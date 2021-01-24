        private generated = null;
        private List<NotificationsClass> notifications;
        public List<NotificationsClass> Notifications 
        {
            get 
            {
                 return notifications;
            }
            set
            {
                if(generated != null)
                {
                    notifications = generated ;
                    notifications.AddRange(value);
                    generated = null
                 }
                 else
                    notifications = value;
            }
        
        }
    
    public MyClass () {
            generated = notificationsGENERATEDList;
        }
