            string[] input = new string[] { "1B", "2C", "01", "11", "3F", "5F", "02", "01", "06", "12", "1C" };
            string splitStr = "01";
            int firstPos = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == splitStr)
                {
                    firstPos = i;
                    break;
                }
            }
            var data = input.Skip(firstPos).ToArray() ;
            List<string> result = new List<string>();
            int index = -1;
            string tmp = string.Empty;
            while(++index < data.Length)
            {
                if(data[index] == splitStr && tmp != string.Empty)
                {
                        result.Add(tmp);
                        tmp = string.Empty;
                }
                tmp += data[index];
                if(index == data.Length - 1 && tmp != string.Empty)
                    result.Add(tmp);
            }
            //results:
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
