        protected override void Seed(Pmg2TrackerContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "pmg2_tracker_net.DAL.CustomCalJobTracker.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.MissingFieldFound = null;
                    var records = new List<Assignment>();
                    csvReader.Read();
                    csvReader.ReadHeader();
                    while (csvReader.Read())
                    {
                        var assignment = new Assignment
                        {
                            Id = csvReader.GetField<int>("Id"),
                            Vpcr = csvReader.GetField("Vpcr"),
                            <SNIP>
                            InitiatedDate = ConvertBadDate(csvReader.GetField("InitiatedDate")),
                            TechScreeningRequestDate = ConvertBadDate(csvReader.GetField("TechScreeningRequestDate")),
                            TechScreeningCompletionDate = ConvertBadDate(csvReader.GetField("TechScreeningCompletionDate")),
                            <SNIP>
                        };
                        string status_string = csvReader.GetField<string>("Status");
                        assignment.Status = context.Statuses.First(s => s.Designation == status_string);
                        context.Assignments.AddOrUpdate(a => a.Vpcr, assignment);
                    }
                }
            }
            base.Seed(context);
        }
        private DateTime ConvertBadDate(string PossibleDate)
        {
            DateTime val;
            if (DateTime.TryParse(PossibleDate, out val))
            {
                Console.WriteLine("Converted '{0}' to {1}.", PossibleDate, val);
                return val;
            }
            else
            {
                Console.WriteLine("Unable to convert '{0}' to a date.", PossibleDate);
                return DateTime.Now;
            }
        }
