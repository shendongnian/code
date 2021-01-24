    using System;
    using System.Collections.Generic;
    namespace ConsoleApp1
    {
    class Program
    {
        static void Main(string[] args)
        {            
            string input = "{1, 'hello', 1, 3}, {2, 'othello', 0, 2}";
            //get the first start open curly
            int start = input.IndexOf('{');
            List<Data> list = new List<Data>();
            while (start >= 0)
            {
                //find position of first close curly after our open curly
                var end = input.IndexOf('}', start);
                //get all values between curlys
                var setValues = input.Substring(start + 1, (end - 1) - start);
                //split them into array
                var split = setValues.Split(',');
                list.Add(new Data()
                {
                    Id = Convert.ToInt32(split[0]),
                    Desc = split[1],
                    State = Convert.ToInt32(split[2]),
                    Res = Convert.ToInt32(split[3])
                });
                //get next open curly based off of most recent closed curly position
                start = input.IndexOf('{', end);
            }
        }
    }
        public class Data
        {
            public int Id { get; set; }
            public string Desc { get; set; }
            public int State { get; set; }
            public int Res { get; set; }
        }
    }
