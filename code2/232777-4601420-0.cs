            Random randF = new Random();
            List<double> nums = new List<double>();
            for (int i = 0; i < 100000; i++)
            {
                nums.Add(randF.NextDouble()*100);
            }
            double fromXF = 30;
            double toXF = 80;
            int groupCount = 10; // number of groups between values
            var histF = from i in nums
                        let groupKeyF = ((i-fromXF)/(toXF-fromXF)*groupCount) // even distribution of "groupCount" groups between fromXF and toXF, simple math, really
                        where groupKeyF >= 0 && groupKeyF < groupCount // only groups we want
                        let groupKey = (int)groupKeyF // clamp it to only group number
                        group i by groupKey into gr  // group it according to group number
                        orderby gr.Key
                        select new { Value = gr.Key, Count = gr.Count() };
            foreach (var item in histF)
            {
                Console.WriteLine("Group number: " + item.Value + ", Count: " + item.Count);
            }
