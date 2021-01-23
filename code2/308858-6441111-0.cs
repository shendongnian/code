            var input = "\r\n21.what is your favourite pet name?\r\nA.Cat B.Dog\r\nC.Horse D.Snake\r\n22.Which country produce wheat most?\r\nA.Australia B.Bhutan\r\nC.India D.Canada.";
            var pattern1 = @"(?<Question>\d+\.[^?]+\?)(?:(?:\W*)(?<Answer>[ABCD]\..*?(?=$|(?:\s|\r\n)(?:[ABCD]\.|\d+\.))))*";
            var pattern2 = @"\d+\.(?<Question>[^?]+\?)(?:(?:\W*)[ABCD]\.(?<Answer>.*?(?=$|(?:\s|\r\n)(?:[ABCD]\.|\d+\.))))*";
            foreach (Match m in Regex.Matches(input, pattern2))
            {
                var question = m.Groups["Question"].Value;
                var answers = (from Capture cap in m.Groups["Answer"].Captures
                               select cap.Value).ToList();
                Console.WriteLine("Question: {0}", question);
                foreach (var answer in answers)
                {
                    Console.WriteLine("Answer: {0}", answer);
                }
            }
            Console.ReadLine();
