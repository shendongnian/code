        public class Result
        {
            public List<List<object>> Data { get; set; }
            public List<string> Headers { get; set; }
            public List<string> Footer { get; set; }
        }
        public class ReportRootObject
        {
            public string S { get; set; }
            public Result Result { get; set; }
        }
        static void Main(string[] args)
        {
            string response = "{\"S\":\"Success\",\"Result\":{\"Data\":[[2251,2570205,\"05 - Sep - 19 09:53 AM\",\"--\",\"Rs. 0\",\"Cash\",\"Amount Paid : 0\"],[2248,3817456,\"01 - Sep - 19 08:53 AM\",\"--\",\"Rs. 168.00\",\"NC\",\"Reason: NC\"],[2247,2997168,\"01 - Sep - 19 08:49 AM\",\"16\",\"Rs. 660.00\",\"Card\",\"Amount Paid : 660, Type: Visa\"],[2245,6410400,\"01 - Sep - 19 08:46 AM\",\"16\",\"Rs. 726.00\",\"Card\",\"Amount Paid : 726, Type: Visa\"]],\"Headers\":[\"S.No.\",\"Order Id\",\"Date\",\"Table No\",\"Amount\",\"Mode of Payment\",\"More Info\"],\"Footer\":[\"Total\",\"4\",\"\",\"\",\"Rs. 1,386.00\",\"\",\"\"]}}";
            ReportRootObject jsonResult = new ReportRootObject();
            JsonConvert.PopulateObject(response, jsonResult);
            Console.WriteLine($"SerialNumber: {jsonResult.Result.Data[0][0]}");
        }
