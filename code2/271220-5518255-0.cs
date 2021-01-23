    string[] prizes = new string[]
            {
                "Prize 1",
                "Prize 2",
                "Prize 3",
                "Prize 4",
                "Prize 5"
            };
            Random r = new Random();
            var choices = prizes.OrderBy(x => r.Next()).Take(3).ToArray();
            string firstDoor = choices[0];
            string secondDoor = choices[1];
            string thirdDoor = choices[2];
