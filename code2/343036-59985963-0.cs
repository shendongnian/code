    using System;
    using System.Windows;
    class LongLivingSubject
    { 
        public event EventHandler<EventArgs> Notifications = delegate { }; 
    }
    class ShortLivingObserver
    {
        public ShortLivingObserver(LongLivingSubject subject)
        { 
            WeakEventManager<LongLivingSubject, EventArgs>
                .AddHandler(subject, nameof(subject.Notifications), Subject_Notifications); 
        }
        private void Subject_Notifications(object sender, EventArgs e) 
        { 
        }
    }
