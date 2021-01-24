    public class DateRange
    {
        public DateRange(DateTime from){
            this._from = from.Date;
        }
        private DateTime _from;
        public DateTime From { set { _from = value.Date; } get { return this._from; } }
        public DateTime To {get { return this._from.Date.AddDays(1).AddTicks(-1); }}
    }
