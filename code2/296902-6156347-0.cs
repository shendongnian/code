        public TimeSpan? Average
        {
            get
            {
                var diff = _dateTimes.Max().Subtract(_dateTimes.Min());
                var avgTs = TimeSpan.FromMilliseconds(diff.TotalMilliseconds / (_dateTimes.Count() - 1));
                return avgTs;
            }
        }
