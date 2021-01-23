    public sealed class ViewModel : DependencyObject
    {
        public ObservableCollection<Activity> Activities 
               { get; private set; }
        public ObservableCollection<ActivityStatus> Statuses 
               { get; private set; }
        public static readonly DependencyProperty 
            SelectedActivityProperty =
            DependencyProperty.Register(
                "SelectedActivity",
                typeof(Activity),
                typeof(ViewModel),
                new UIPropertyMetadata(null));
        public Activity SelectedActivity
        {
            get { return (Activity)GetValue(SelectedActivityProperty); }
            set { SetValue(SelectedActivityProperty, value); }
        }
        public ViewModel()
        {
            Activities = new ObservableCollection<Activity>();
            Statuses = new ObservableCollection<ActivityStatus>();
            // NOTE!  Each Activity has its own ActivityStatus instance.
            // They have the same Guid and name as the instances in
            // Statuses!!
            for (int i = 1; i <= 4; i++)
            {
                var id = Guid.NewGuid();
                var aname = "Activity " + i;
                var sname = "Status " + i;
                Activities.Add(new Activity
                {
                    Name = aname,
                    Status = new ActivityStatus
                    {
                        Name = sname,
                        Id = id,
                        InstanceType = "Activity"
                    }
                });
                Statuses.Add(new ActivityStatus
                {
                    Name = sname,
                    Id = id,
                    InstanceType = "Collection"
                });
            }
        }
    }
    public sealed class Activity : DependencyObject
    {
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(
                "Name",
                typeof(string),
                typeof(Activity),
                new UIPropertyMetadata(null));
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register(
                "Status",
                typeof(ActivityStatus),
                typeof(Activity),
                new UIPropertyMetadata(null));
        public ActivityStatus Status
        {
            get { return (ActivityStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
    }
    public sealed class ActivityStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// indicates if this instance came from 
        /// the ComboBox or from the Activity
        /// </summary>
        public string InstanceType { get; set; }
        public ActivityStatus()
        {
            Id = Guid.NewGuid();
        }
        public override bool Equals(object otherObject)
        {
            if (!(otherObject is ActivityStatus)) return false;
            return Equals(otherObject as ActivityStatus);
        }
        public bool Equals(ActivityStatus otherStatus)
        {
            if (!(otherStatus is ActivityStatus) ||
                otherStatus == null) return false;
            return Id == otherStatus.Id &&
                Name == otherStatus.Name;
        }
    }
