    public class SuperFastLinqRangeLookup<TItem> : RangeLookupBase<TItem>
        where TItem : RangeItem
    {
        public SuperFastLinqRangeLookup(DateTime start, DateTime end, IEnumerable<TItem> items)
            : base(start, end, items)
        {
            // create delegate only once
            predicate = i => i.IsDayWithinRange(day);
        }
        DateTime day;
        Func<TItem, bool> predicate;
        public override IEnumerable<TItem> GetDayData(DateTime day)
        {
            this.day = day; // set captured day to correct value
            return this.items.Where(predicate);
        }
    }
