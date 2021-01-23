    public static class DateCalcs
    {
        /// <summary>
        /// returns the integer number of years between start and finish
        /// </summary>
        /// <param name="start">Start DateTime</param>
        /// <param name="finish">FinishDateTime</param>
        /// <returns></returns>
        public static int YearDiff(DateTime start, DateTime finish)
        {
            DateTime _start, _finish;
            bool _negate = (finish < start);
            if(_negate)
            {
                _start = finish;
                _finish = start;
            }
            else
            {
                _start = start;
                _finish = finish;
            }
            int _diff = 0;
            while(_start.AddYears(1) < _finish)
            {
                _diff++;
                _start = _start.AddYears(1);
            }
            if(_negate)
            {
                _diff = _diff * (-1);
            }
            return _diff;
        }
        /// <summary>
        /// returns the integer number of months between start and finish
        /// </summary>
        /// <param name="start">Start DateTime</param>
        /// <param name="finish">Finish DateTime</param>
        /// <returns></returns>
        public static int MonthDiff(DateTime start, DateTime finish)
        {
            DateTime _start, _finish;
            bool _negate = (finish < start);
            if (_negate)
            {
                _start = finish;
                _finish = start;
            }
            else
            {
                _start = start;
                _finish = finish;
            }
            int _diff = 0;
            while (_start.AddMonths(1) < _finish)
            {
                _diff++;
                _start = _start.AddMonths(1);
            }
            if (_negate)
            {
                _diff = _diff * (-1);
            }
            return _diff;
        }
        /// <summary>
        /// returns the integer number of days between start and finish
        /// </summary>
        /// <param name="start">start DateTime</param>
        /// <param name="finish">finish DateTime</param>
        /// <returns></returns>
        public static int DayDiff(DateTime start, DateTime finish)
        {
            var _diff = finish - start;
            return (int)_diff.TotalDays;
        }
        /// <summary>
        /// returns the integer number of hours between start and finish
        /// </summary>
        /// <param name="start">start DateTime</param>
        /// <param name="finish">finish DateTime</param>
        /// <returns></returns>
        public static int HourDiff(DateTime start, DateTime finish)
        {
            var _diff = finish - start;
            return(int)_diff.TotalHours;
        }
        /// <summary>
        /// returns the integer number of minutes between start and finish
        /// </summary>
        /// <param name="start">start DateTime</param>
        /// <param name="finish">finish DateTime</param>
        /// <returns></returns>
        public static int MinuteDiff(DateTime start, DateTime finish)
        {
            var _diff = finish - start;
            return (int)_diff.TotalMinutes;
        }
        /// <summary>
        /// returns the integer number of seconds between start and finish
        /// </summary>
        /// <param name="start">start DateTime</param>
        /// <param name="finish">finish DateTime</param>
        /// <returns></returns>
        public static int SecondDiff(DateTime start, DateTime finish)
        {
            var _diff = finish - start;
            return (int)_diff.TotalSeconds;
        }
        /// <summary>
        /// returns the integer number of milliseconds between start and finish
        /// </summary>
        /// <param name="start">start DateTime</param>
        /// <param name="finish">finish DateTime</param>
        /// <returns></returns>
        public static int MilliSecondDiff(DateTime start, DateTime finish)
        {
            var _diff = finish - start;
            return (int)_diff.TotalMilliseconds;
        }
        /// <summary>
        /// returns the integer remaining number of months between two DateTimes 
        /// after the year difference has been removed
        /// </summary>
        /// <param name="start">start DateTime</param>
        /// <param name="finish">finish DateTime</param>
        /// <returns></returns>
        public static int MonthPartDiff(DateTime start, DateTime finish)
        {
            return MonthDiff(start.AddYears(YearDiff(start, finish)), finish);
        }
        /// <summary>
        /// returns the integer remaining number of days between two DateTimes 
        /// after the year difference and the month difference has been removed
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public static int DayPartDiff(DateTime start, DateTime finish)
        {
            return DayDiff(start.AddMonths(MonthDiff(start, finish)), finish);
        }
        /// <summary>
        /// returns the integer remaining number of hours between two DateTimes 
        /// after the year, month and day difference has been removed
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public static int HourPartDiff(DateTime start, DateTime finish)
        {
            return (finish-start).Hours;
        }
        /// <summary>
        /// returns the integer remaining number of minutes between two DateTimes 
        /// after the year, month, day and hour difference has been removed
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public static int MinutePartDiff(DateTime start, DateTime finish)
        {
            return (finish-start).Minutes;
        }
        /// <summary>
        /// returns the integer remaining number of seconds between two DateTimes 
        /// after the year, month, day, hour and minute difference has been removed
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public static int SecondPartDiff(DateTime start, DateTime finish)
        {
            return (finish - start).Seconds;
        }
        /// <summary>
        /// returns the integer remaining number of milliseconds between two DateTimes 
        /// after the year, month, day, hour, minute and second difference has been removed
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public static int MilliSecondPartDiff(DateTime start, DateTime finish)
        {
            return (finish - start).Milliseconds;
        }
    }
