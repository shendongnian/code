        public class VALVERZEROTURN
        {
            public string J_ID { get; set; }
            public string DIS_CODE { get; set; }
        }
        public class RootObject
        {
            public VALVERZEROTURN VAL_VER_ZERO_TURN { get; set; }
        }
        static void Main(string[] args)
        {
            string response = "{\r\n  \"VAL_VER_ZERO_TURN\" : {\r\n    \"J_ID\" : \"345\",\r\n    \"DIS_CODE\" : \"WV345\"\r\n  }\r\n}";
            RootObject rockInfo = new RootObject();
            JsonConvert.PopulateObject(response, rockInfo);
            Console.WriteLine($"J_ID: {rockInfo.VAL_VER_ZERO_TURN.J_ID}, DIS_CODE: {rockInfo.VAL_VER_ZERO_TURN.DIS_CODE} ");
        }
