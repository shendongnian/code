var today = DateTime.Now.Date; // Or DateTime.Today
Context.Category.Where(c => c.CreateAt.Date == today ).AsNoTracking().ToListAsync();
If you want all records for today you can try the following.
var start = DateTime.Today;
var end = Date.Time.Today.AddDays(1); // the following midnight
var todaysCats = Context.Category.Where(c => c.CreateAt >= start && c.CreateAt < end ) // note '>=' and '<'
----
BTW. It' better to use Utc timestamps for `CreatedAt`-like fields. It pays off in the long term.
