public static string GetName([CallerMemberName]string memberName = "") 
   => memberName; 
# Test
## Code 
    class ReportResult { 
        //(...)
        public string WhoMadeMe {get;set;}
    }
    class Program
    {
        public static string GetName([CallerMemberName]string memberName = "") 
            => memberName; 
        public async static Task Main()
        {
            var offset = 1;
            var limit = 10;
             List<ReportResult> results = new List<ReportResult>() {
                await GetInvalid("ASC", offset, limit),
                await GetActive("ASC", offset, limit),
                await GetValid("ASC", offset, limit)
            };
            foreach(var r in results ) Console.WriteLine(r.WhoMadeMe);
        }
        private static Task<ReportResult> GetValid(string v, object offset, object limit) {
            return Task.FromResult(new ReportResult{  WhoMadeMe = GetName() });
        }
        private static Task<ReportResult> GetActive(string v, object offset, object limit) {
            return Task.FromResult(new ReportResult{ WhoMadeMe = GetName() });
        }
        private static Task<ReportResult> GetInvalid(string v, object offset, object limit) {
            return Task.FromResult(new ReportResult{ WhoMadeMe = GetName() });
        }
## Output
GetInvalid
GetActive
GetValid
