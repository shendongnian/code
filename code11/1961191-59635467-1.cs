        static void Main(string[] args)
        {
            standardMessage myMessage = new standardMessage();
            myMessage.message = new messageProperties
            {
                messageSubject = "Greetings",
                messageBody = "Happy Weekend"
            };
            myMessage.flag = new messageFlag
            {
                flagImportant = false,
                flagPersonal = true
            };
            int loopCount = 100000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < loopCount; i++)
            {
                string val = Newtonsoft.Json.JsonConvert.SerializeObject(myMessage);
            }
            var serializedTicks = sw.ElapsedTicks;
            for (var i = 0; i < loopCount; i++)
            {
                string val = PrintObject(myMessage);
            }
            var reflectionTicks = sw.ElapsedTicks;
            sw.Stop();
        }
