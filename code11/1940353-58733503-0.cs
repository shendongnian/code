    public class Job
    { 
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
    }
    // You need to have this list ordered by DueDate....
    List<Job> myJobs = new List<Job>
    {
        new Job{ID = 6, Name = "Job6", DueDate = new DateTime(2019,11,6,0,0,0)},
        new Job{ID = 7, Name = "Job7", DueDate = new DateTime(2019,11,6,0,0,0)},
        new Job{ID = 1, Name = "Job1", DueDate = new DateTime(2019,11,6,12,52,0)},
        new Job{ID = 2, Name = "Job2", DueDate = new DateTime(2019,11,6,13,51,0)},
        new Job{ID = 3, Name = "Job3", DueDate = new DateTime(2019,11,6,14,50,0)},
        new Job{ID = 4, Name = "Job4", DueDate = new DateTime(2019,11,6,15,49,0)},
    };
    
    Dictionary<int, List<Job>> grouped = new Dictionary<int, List<Job>>();
    foreach (Job j in myJobs)
    {
        int key = j.DueDate.Hour * 60 + j.DueDate.Minute;
        if(key == 0) key = -1; // for distinguish jobs due at midnight.
        int v = grouped.Keys.FirstOrDefault(k => (key - k) <= 60);
        if (v == 0)
            grouped.Add(key, new List<Job>(new Job[] { j}));
        else
            grouped[v].Add(j);
    }
