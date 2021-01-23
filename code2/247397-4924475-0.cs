        public SpssMap()
        {
           Table("myViewBame"); // ADD THIS
            Id(x => x.StudentId).GeneratedBy.Assigned();
            Map(x => x.UPNSCN);
            ...
        }
