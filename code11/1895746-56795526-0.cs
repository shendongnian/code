            var list = new List<Tuple<object, int, int>> // item2 - UserId, item3 - InviterId
            {
                new Tuple<object, int, int>(new { Name = "Ivan" }, 1, 12),
                new Tuple<object, int, int>(new { Name = "George" }, 2, 3),
                new Tuple<object, int, int>(new { Name = "Phil" }, 3, 12),
                new Tuple<object, int, int>(new { Name = "John" }, 4, 3),
                new Tuple<object, int, int>(new { Name = "Giggs" }, 5, 1),
                new Tuple<object, int, int>(new { Name = "Higgins" }, 6, 1)
            };
            var groups = list.GroupBy(i => i.Item3);
            var groupedList = new List<string>();
            foreach (var user in list)
            {
                //I'm assuming you actually want to display / store the data as per your results
                var propInfo = user.Item1.GetType().GetProperty("Name");
                groupedList.Add(propInfo.GetValue(user.Item1, null).ToString() + " (user id = " + user.Item2 + ")");
                var group = groups.Where(grp => grp.Key == user.Item2).ToList().SelectMany(g => g);
                foreach (var inviter in group)
                {
                    groupedList.Add(propInfo.GetValue(inviter.Item1, null).ToString() + " (inviter id = " + inviter.Item3 + ")");
                }
            }
            // display items in list
            foreach (var item in groupedList)
            {
                Console.WriteLine(item);
            }
