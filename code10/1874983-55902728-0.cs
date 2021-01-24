        static void Main(string[] args)
        {
            using (WebClient webClient = new WebClient())
            {
                //Bid Ask Curves
                var bidAskCurves = webClient.DownloadString("https://reports.semopx.com/documents/BidAskCurves_NI-IDA3_20190401_20190401161933.xml");
                var serializer = new XmlSerializer(typeof(BidAskCurves));
                BidAskCurves result;
                using (TextReader reader = new StringReader(bidAskCurves))
                {
                    // here it is
                    result = (BidAskCurves)serializer.Deserialize(reader);
                }
            }
            Console.ReadKey();
        }
