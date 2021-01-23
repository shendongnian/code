            DateTime startDate = new DateTime(2011, 1, 1).Date;
            DateTime now = DateTime.Now.Date;
            int days = (int)now.Subtract(startDate).TotalDays;
            int weeks = days / 7;
            Console.WriteLine((weeks % 3) + 1);
