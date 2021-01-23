            List<string> possible = new List<string> { "091-555-8888", 
    "0915-888-4444", 
    "0930-885-8844", 
    "0955-888-8842" };
            string regex = @"09(1\d|3[1-9])-\d{3}-\d{4}$";
            foreach (string number in possible)
            {
                Console.WriteLine("{0} is{1} an Iranian number", number, Regex.IsMatch(number, regex) ? "" : " not");
            }
