    List<Banner> list = Database.Banners.Where(b => b.IsPublish.Value && 
             b.Category.Value == (int) CategoryBanner.Banner &&
             b.PeriodShowCountAlready < b.PeriodShowCount ||
             b.ShowNext < DateTime.Now ).Take(10).ToList();
    
    Random r = new Random();
    Banner banner = list.Count == 0 ? null : list[r.Next(0, list.Count)];
