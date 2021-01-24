    namespace ConsoleApp3
    {
     
        public class JobsJson
        {
            public List<Job> Jobs { get; set; }
        }
        public class Job
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public Location Location { get; set; }
            public DateTime LastUpdated { get; set; }
        }
     
        public class Location
        {
            public string Name { get; set; }
        }
     
        class GreenhouseJobsClient
        {
            static HttpClient client = new HttpClient();
     
            static void ShowJobs(List<Job> jobs)
            {
                foreach (var job in jobs)
                {
                    Console.WriteLine($"Id: {job.Id}\tTitle: " +
                                      $"{job.Title}\tLocation: {job.Location}\tLast Updated: {job.LastUpdated}");
                }
            }
           
     
            static async Task<List<Job>> GetJobAsync(string path)
            {
                var jobs = new List<Job>();
                HttpResponseMessage response = await client.GetAsync(path);
     
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var re = JsonConvert.DeserializeObject<JobsJson>(stringResponse);
                    jobs = re.Jobs;
                }
                return jobs;
            }
     
            static void Main()
            {
                RunAsync().GetAwaiter().GetResult();
                Console.ReadLine();
            }
     
            static async Task RunAsync()
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("https://boards-api.greenhouse.io/v1/boards/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     
                try
                {
                    // Get the product
                    var jobs = await GetJobAsync("vaulttec/jobs");
                    ShowJobs(jobs);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
     
                Console.ReadLine();
            }
        }
    }
