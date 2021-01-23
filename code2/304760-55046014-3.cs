    [TestMethod]
        public void TestNextDate()
        {
            var date = new DateTime(2013, 7, 15);
            var start = date;
            //testing same month - forwardOnly
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Tuesday)); //16
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Wednesday)); //17
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Thursday)); //18
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Friday)); //19
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Saturday)); //20
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Sunday)); //21
            Assert.AreEqual(start.AddDays(1), date.GetNextDate(DayOfWeek.Monday)); //22
            //testing same month - include date
            Assert.AreEqual(start = date, date.GetNextDate(DayOfWeek.Monday, false)); //15
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Tuesday, false)); //16
            Assert.AreEqual(start.AddDays(1), date.GetNextDate(DayOfWeek.Wednesday, false)); //17
            //testing month change - forwardOnly
            date = new DateTime(2013, 7, 29);
            start = date;
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Tuesday)); //30
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Wednesday)); //31
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Thursday)); //2013/09/01-month increased
            Assert.AreEqual(start.AddDays(1), date.GetNextDate(DayOfWeek.Friday)); //02
            //testing year change
            date = new DateTime(2013, 12, 30);
            start = date;
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Tuesday)); //31
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Wednesday)); //2014/01/01 - year increased
            Assert.AreEqual(start = start.AddDays(1), date.GetNextDate(DayOfWeek.Thursday)); //02
        }
