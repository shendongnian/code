            var MinDate = DateTime.MinValue;
            var OneHour = MinDate.AddHours(1);
            var OneDay = MinDate.AddDays(1);
            var tests = new Dictionary<string, DateTime>
            {
                { nameof(MinDate), DateTime.MinValue },
                { nameof(OneDay), OneDay },
                { nameof(OneHour), OneHour },
                { nameof(DateTime.Now), DateTime.Now },
                { nameof(DateTime.Today), DateTime.Today },
            };
            var infos = tests.Select(x =>
            {
                var dateInfo = new DateInfo(x.Value);
                return new { x.Key, dateInfo.HasDate, dateInfo.HasTime };
            });
            tests.ToList().ForEach(test =>
            {
                var dateInfo = new DateInfo(test.Value);
                System.Diagnostics.Debug.WriteLine($"{test.Key}: {dateInfo}");
            });
