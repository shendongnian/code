        public class MyDate : IComparable<MyDate>
        {
            public enum MyMonth { Jan = 1 , Feb , Mar , Apr , May , Jun , Jul , Aug , Sep , Oct , Nov , Dec , }
            public int     Year   ;
            public MyMonth Month  ;
            public int     Day    ;
            public int     Hour   ;
            public int     Minute ;
            public int     Second ;
            private static Comparer _comparerInstance = null ;
            private static Comparer comparerInstance
            {
                get
                {
                    if ( _comparerInstance == null )
                    {
                        _comparerInstance = new Comparer() ;
                    }
                    return _comparerInstance ;
                }
            }
            public class Comparer : IComparer<MyDate> 
            {
                #region IComparer<MyDate> Members
                
                public int Compare(MyDate x, MyDate y)
                {
                    if ( x == null || y == null ) throw new ArgumentNullException() ;
                    if ( object.ReferenceEquals(x,y) ) return 0 ;
                    int rc ;
                    if (      x.Year < y.Year ) rc = -1 ;
                    else if ( x.Year > y.Year ) rc = +1 ;
                    else // x.Year == y.Year
                    {
                        if (      x.Month < y.Month ) rc = -1 ;
                        else if ( x.Month > y.Month ) rc = +1 ;
                        else // x.Month == y.Month
                        {
                            if (      x.Day < y.Day ) rc = -1 ;
                            else if ( x.Day > y.Day ) rc = +1 ;
                            else // x.Day == y.Day
                            {
                                if (      x.Hour < y.Hour ) rc = -1 ;
                                else if ( x.Hour > y.Hour ) rc = +1 ;
                                else // x.Hour == y.Hour
                                {
                                    if (      x.Minute < y.Minute ) rc = -1 ;
                                    else if ( x.Minute > y.Minute ) rc = +1 ;
                                    else // x.Minute = y.Minute
                                    {
                                        if (      x.Second < y.Second ) rc = -1 ;
                                        else if ( x.Second > y.Second ) rc = -1 ;
                                        else /* x.Second == y.Seconds */ rc = 0 ;
                                    }
                                }
                            }
                        }
                    }
                    return rc ;
                }
                #endregion
            }
            #region IComparable<MyDate> Members
            public int CompareTo( MyDate other )
            {
                return comparerInstance.Compare( this , other ) ;
            }
            #endregion
        }
