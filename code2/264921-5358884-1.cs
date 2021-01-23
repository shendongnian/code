    [Serializable]
    public struct DateTime : IComparable, IFormattable, IConvertible, ISerializable, IComparable<DateTime>, IEquatable<DateTime>
    {
        // Fields
        private ulong dateData;
        private const string DateDataField = "dateData";
        private const int DatePartDay = 3;
        private const int DatePartDayOfYear = 1;
        private const int DatePartMonth = 2;
        private const int DatePartYear = 0;
        private const int DaysPer100Years = 0x8eac;
        private const int DaysPer400Years = 0x23ab1;
        private const int DaysPer4Years = 0x5b5;
        private const int DaysPerYear = 0x16d;
        private const int DaysTo10000 = 0x37b9db;
        private const int DaysTo1601 = 0x8eac4;
        private const int DaysTo1899 = 0xa9559;
        private static readonly int[] DaysToMonth365;
        private static readonly int[] DaysToMonth366;
        private const long DoubleDateOffset = 0x85103c0cb83c000L;
        private const long FileTimeOffset = 0x701ce1722770000L;
        private const ulong FlagsMask = 13835058055282163712L;
        private const ulong KindLocal = 9223372036854775808L;
        private const ulong KindLocalAmbiguousDst = 13835058055282163712L;
        private const int KindShift = 0x3e;
        private const ulong KindUnspecified = 0L;
        private const ulong KindUtc = 0x4000000000000000L;
        private const ulong LocalMask = 9223372036854775808L;
        private const long MaxMillis = 0x11efae44cb400L;
        internal const long MaxTicks = 0x2bca2875f4373fffL;
        public static readonly DateTime MaxValue;
        private const int MillisPerDay = 0x5265c00;
        private const int MillisPerHour = 0x36ee80;
        private const int MillisPerMinute = 0xea60;
        private const int MillisPerSecond = 0x3e8;
        internal const long MinTicks = 0L;
        public static readonly DateTime MinValue;
        private const double OADateMaxAsDouble = 2958466.0;
        private const double OADateMinAsDouble = -657435.0;
        private const long OADateMinAsTicks = 0x6efdddaec64000L;
        private const long TicksCeiling = 0x4000000000000000L;
        private const string TicksField = "ticks";
        private const ulong TicksMask = 0x3fffffffffffffffL;
        private const long TicksPerDay = 0xc92a69c000L;
        private const long TicksPerHour = 0x861c46800L;
        private const long TicksPerMillisecond = 0x2710L;
        private const long TicksPerMinute = 0x23c34600L;
        private const long TicksPerSecond = 0x989680L;
    
        // Methods
        static DateTime();
        public DateTime(long ticks);
        private DateTime(ulong dateData);
        public DateTime(long ticks, DateTimeKind kind);
        private DateTime(SerializationInfo info, StreamingContext context);
        public DateTime(int year, int month, int day);
        internal DateTime(long ticks, DateTimeKind kind, bool isAmbiguousDst);
        public DateTime(int year, int month, int day, Calendar calendar);
        public DateTime(int year, int month, int day, int hour, int minute, int second);
        public DateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind);
        public DateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind);
        public DateTime Add(TimeSpan value);
        private DateTime Add(double value, int scale);
        public DateTime AddDays(double value);
        public DateTime AddHours(double value);
        public DateTime AddMilliseconds(double value);
        public DateTime AddMinutes(double value);
        public DateTime AddMonths(int months);
        public DateTime AddSeconds(double value);
        public DateTime AddTicks(long value);
        public DateTime AddYears(int value);
        public static int Compare(DateTime t1, DateTime t2);
        public int CompareTo(DateTime value);
        public int CompareTo(object value);
        private static long DateToTicks(int year, int month, int day);
        public static int DaysInMonth(int year, int month);
        internal static long DoubleDateToTicks(double value);
        public bool Equals(DateTime value);
        public override bool Equals(object value);
        public static bool Equals(DateTime t1, DateTime t2);
        public static DateTime FromBinary(long dateData);
        internal static DateTime FromBinaryRaw(long dateData);
        public static DateTime FromFileTime(long fileTime);
        public static DateTime FromFileTimeUtc(long fileTime);
        public static DateTime FromOADate(double d);
        private int GetDatePart(int part);
        public string[] GetDateTimeFormats();
        public string[] GetDateTimeFormats(char format);
        public string[] GetDateTimeFormats(IFormatProvider provider);
        public string[] GetDateTimeFormats(char format, IFormatProvider provider);
        public override int GetHashCode();
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern long GetSystemTimeAsFileTime();
        public TypeCode GetTypeCode();
        internal bool IsAmbiguousDaylightSavingTime();
        public bool IsDaylightSavingTime();
        public static bool IsLeapYear(int year);
        public static DateTime operator +(DateTime d, TimeSpan t);
        public static bool operator ==(DateTime d1, DateTime d2);
        public static bool operator >(DateTime t1, DateTime t2);
        public static bool operator >=(DateTime t1, DateTime t2);
        public static bool operator !=(DateTime d1, DateTime d2);
        public static bool operator <(DateTime t1, DateTime t2);
        public static bool operator <=(DateTime t1, DateTime t2);
        public static TimeSpan operator -(DateTime d1, DateTime d2);
        public static DateTime operator -(DateTime d, TimeSpan t);
        public static DateTime Parse(string s);
        public static DateTime Parse(string s, IFormatProvider provider);
        public static DateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles);
        public static DateTime ParseExact(string s, string format, IFormatProvider provider);
        public static DateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style);
        public static DateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style);
        public static DateTime SpecifyKind(DateTime value, DateTimeKind kind);
        public TimeSpan Subtract(DateTime value);
        public DateTime Subtract(TimeSpan value);
        bool IConvertible.ToBoolean(IFormatProvider provider);
        byte IConvertible.ToByte(IFormatProvider provider);
        char IConvertible.ToChar(IFormatProvider provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider);
        double IConvertible.ToDouble(IFormatProvider provider);
        short IConvertible.ToInt16(IFormatProvider provider);
        int IConvertible.ToInt32(IFormatProvider provider);
        long IConvertible.ToInt64(IFormatProvider provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider);
        float IConvertible.ToSingle(IFormatProvider provider);
        object IConvertible.ToType(Type type, IFormatProvider provider);
        ushort IConvertible.ToUInt16(IFormatProvider provider);
        uint IConvertible.ToUInt32(IFormatProvider provider);
        ulong IConvertible.ToUInt64(IFormatProvider provider);
        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context);
        private static double TicksToOADate(long value);
        private static long TimeToTicks(int hour, int minute, int second);
        public long ToBinary();
        internal long ToBinaryRaw();
        public long ToFileTime();
        public long ToFileTimeUtc();
        public DateTime ToLocalTime();
        public string ToLongDateString();
        public string ToLongTimeString();
        public double ToOADate();
        public string ToShortDateString();
        public string ToShortTimeString();
        public override string ToString();
        public string ToString(IFormatProvider provider);
        public string ToString(string format);
        public string ToString(string format, IFormatProvider provider);
        public DateTime ToUniversalTime();
        internal static bool TryCreate(int year, int month, int day, int hour, int minute, int second, int millisecond, out DateTime result);
        public static bool TryParse(string s, out DateTime result);
        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result);
        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style, out DateTime result);
        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result);
    
        // Properties
        public DateTime Date { get; }
        public int Day { get; }
        public DayOfWeek DayOfWeek { get; }
        public int DayOfYear { get; }
        public int Hour { get; }
        private ulong InternalKind { get; }
        private long InternalTicks { get; }
        public DateTimeKind Kind { get; }
        public int Millisecond { get; }
        public int Minute { get; }
        public int Month { get; }
        public static DateTime Now { get; }
        public int Second { get; }
        public long Ticks { get; }
        public TimeSpan TimeOfDay { get; }
        public static DateTime Today { get; }
        public static DateTime UtcNow { get; }
        public int Year { get; }
    }
    
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public struct TimeSpan : IComparable, IComparable<TimeSpan>, IEquatable<TimeSpan>
    {
        public const long TicksPerMillisecond = 0x2710L;
        private const double MillisecondsPerTick = 0.0001;
        public const long TicksPerSecond = 0x989680L;
        private const double SecondsPerTick = 1E-07;
        public const long TicksPerMinute = 0x23c34600L;
        private const double MinutesPerTick = 1.6666666666666667E-09;
        public const long TicksPerHour = 0x861c46800L;
        private const double HoursPerTick = 2.7777777777777777E-11;
        public const long TicksPerDay = 0xc92a69c000L;
        private const double DaysPerTick = 1.1574074074074074E-12;
        private const int MillisPerSecond = 0x3e8;
        private const int MillisPerMinute = 0xea60;
        private const int MillisPerHour = 0x36ee80;
        private const int MillisPerDay = 0x5265c00;
        private const long MaxSeconds = 0xd6bf94d5e5L;
        private const long MinSeconds = -922337203685L;
        private const long MaxMilliSeconds = 0x346dc5d638865L;
        private const long MinMilliSeconds = -922337203685477L;
        public static readonly TimeSpan Zero;
        public static readonly TimeSpan MaxValue;
        public static readonly TimeSpan MinValue;
        internal long _ticks;
        public TimeSpan(long ticks);
        public TimeSpan(int hours, int minutes, int seconds);
        public TimeSpan(int days, int hours, int minutes, int seconds);
        public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);
        public long Ticks { get; }
        public int Days { get; }
        public int Hours { get; }
        public int Milliseconds { get; }
        public int Minutes { get; }
        public int Seconds { get; }
        public double TotalDays { get; }
        public double TotalHours { get; }
        public double TotalMilliseconds { get; }
        public double TotalMinutes { get; }
        public double TotalSeconds { get; }
        public TimeSpan Add(TimeSpan ts);
        public static int Compare(TimeSpan t1, TimeSpan t2);
        public int CompareTo(object value);
        public int CompareTo(TimeSpan value);
        public static TimeSpan FromDays(double value);
        public TimeSpan Duration();
        public override bool Equals(object value);
        public bool Equals(TimeSpan obj);
        public static bool Equals(TimeSpan t1, TimeSpan t2);
        public override int GetHashCode();
        public static TimeSpan FromHours(double value);
        private static TimeSpan Interval(double value, int scale);
        public static TimeSpan FromMilliseconds(double value);
        public static TimeSpan FromMinutes(double value);
        public TimeSpan Negate();
        public static TimeSpan Parse(string s);
        public static bool TryParse(string s, out TimeSpan result);
        public static TimeSpan FromSeconds(double value);
        public TimeSpan Subtract(TimeSpan ts);
        public static TimeSpan FromTicks(long value);
        internal static long TimeToTicks(int hour, int minute, int second);
        private string IntToString(int n, int digits);
        public override string ToString();
        public static TimeSpan operator -(TimeSpan t);
        public static TimeSpan operator -(TimeSpan t1, TimeSpan t2);
        public static TimeSpan operator +(TimeSpan t);
        public static TimeSpan operator +(TimeSpan t1, TimeSpan t2);
        public static bool operator ==(TimeSpan t1, TimeSpan t2);
        public static bool operator !=(TimeSpan t1, TimeSpan t2);
        public static bool operator <(TimeSpan t1, TimeSpan t2);
        public static bool operator <=(TimeSpan t1, TimeSpan t2);
        public static bool operator >(TimeSpan t1, TimeSpan t2);
        public static bool operator >=(TimeSpan t1, TimeSpan t2);
        static TimeSpan();
        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        private struct StringParser
        {
            private string str;
            private char ch;
            private int pos;
            private int len;
            private ParseError error;
            internal void NextChar();
            internal char NextNonDigit();
            internal long Parse(string s);
            internal bool TryParse(string s, out long value);
            internal bool ParseInt(int max, out int i);
            internal bool ParseTime(out long time);
            internal void SkipBlanks();
            // Nested Types
            private enum ParseError
            {
                ArgumentNull = 4,
                Format = 1,
                Overflow = 2,
                OverflowHoursMinutesSeconds = 3
            }
        }
    }
