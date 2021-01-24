        public ViewResult List()
        {
            DateTime startOfCurrentWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
            DateTime startOfNextWeek = startOfCurrentWeek.AddDays(8);
            DateTime endOfNextWeek = startOfCurrentWeek.AddDays(14);
            return View(repository.Days
                .Where(d => d.date >= startOfNextWeek && d.date <= endOfNextWeek));
        }
