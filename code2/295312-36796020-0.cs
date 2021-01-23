    using System;
    
    public struct DateOnly : IComparable, IFormattable, IComparable<DateOnly>, IEquatable<DateOnly>
    {
    
    	private DateTime _dateValue;
    
    	public int CompareTo(object obj)
    	{
    		if (obj == null)
    		{
    			return 1;
    		}
    
    		DateOnly otherDateOnly = (DateOnly)obj;
    		if (otherDateOnly != null)
    		{
    			return ToDateTime().CompareTo(otherDateOnly.ToDateTime());
    		}
    		else
    		{
    			throw new ArgumentException("Object is not a DateOnly");
    		}
    	}
    
    	int IComparable<DateOnly>.CompareTo(DateOnly other)
    	{
    		return this.CompareToOfT(other);
    	}
    	public int CompareToOfT(DateOnly other)
    	{
    		// If other is not a valid object reference, this instance is greater.
    		if (other == new DateOnly())
    		{
    			return 1;
    		}
    		return this.ToDateTime().CompareTo(other.ToDateTime());
    	}
    
    	bool IEquatable<DateOnly>.Equals(DateOnly other)
    	{
    		return this.EqualsOfT(other);
    	}
    	public bool EqualsOfT(DateOnly other)
    	{
    		if (other == new DateOnly())
    		{
    			return false;
    		}
    
    		if (this.Year == other.Year && this.Month == other.Month && this.Day == other.Day)
    		{
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}
    
    	public static DateOnly Now()
    	{
    		return new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    	}
    
    	public static bool TryParse(string s, ref DateOnly result)
    	{
    		DateTime dateValue = default(DateTime);
    		if (DateTime.TryParse(s, out dateValue))
    		{
    			result = new DateOnly(dateValue.Year, dateValue.Month, dateValue.Day);
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}
    
    	public static DateOnly Parse(string s)
    	{
    		DateTime dateValue = default(DateTime);
    		dateValue = DateTime.Parse(s);
    		return new DateOnly(dateValue.Year, dateValue.Month, dateValue.Day);
    	}
    
    	public static DateOnly ParseExact(string s, string format)
    	{
    		CultureInfo provider = CultureInfo.InvariantCulture;
    		DateTime dateValue = default(DateTime);
    		dateValue = DateTime.ParseExact(s, format, provider);
    		return new DateOnly(dateValue.Year, dateValue.Month, dateValue.Day);
    	}
    
    	public DateOnly(int yearValue, int monthValue, int dayValue) : this()
    	{
    		Year = yearValue;
    		Month = monthValue;
    		Day = dayValue;
    	}
    
    	public DateOnly AddDays(double value)
    	{
    		DateTime d = new DateTime(this.Year, this.Month, this.Day);
    		d = d.AddDays(value);
    		return new DateOnly(d.Year, d.Month, d.Day);
    	}
    
    	public DateOnly AddMonths(int months)
    	{
    		DateTime d = new DateTime(this.Year, this.Month, this.Day);
    		d = d.AddMonths(months);
    		return new DateOnly(d.Year, d.Month, d.Day);
    	}
    
    	public DateOnly AddYears(int years)
    	{
    		DateTime d = new DateTime(this.Year, this.Month, this.Day);
    		d = d.AddYears(years);
    		return new DateOnly(d.Year, d.Month, d.Day);
    	}
    
    	public DayOfWeek DayOfWeek
    	{
    		get
    		{
    			return _dateValue.DayOfWeek;
    		}
    	}
    
    	public DateTime ToDateTime()
    	{
    		return _dateValue;
    	}
    
    	public int Year
    	{
    		get
    		{
    			return _dateValue.Year;
    		}
    		set
    		{
    			_dateValue = new DateTime(value, Month, Day);
    		}
    	}
    
    	public int Month
    	{
    		get
    		{
    			return _dateValue.Month;
    		}
    		set
    		{
    			_dateValue = new DateTime(Year, value, Day);
    		}
    	}
    
    	public int Day
    	{
    		get
    		{
    			return _dateValue.Day;
    		}
    		set
    		{
    			_dateValue = new DateTime(Year, Month, value);
    		}
    	}
    
    	public static bool operator == (DateOnly aDateOnly1, DateOnly aDateOnly2)
    	{
    		return (aDateOnly1.ToDateTime() == aDateOnly2.ToDateTime());
    	}
    
    	public static bool operator != (DateOnly aDateOnly1, DateOnly aDateOnly2)
    	{
    		return (aDateOnly1.ToDateTime() != aDateOnly2.ToDateTime());
    	}
    
    	public static bool operator > (DateOnly aDateOnly1, DateOnly aDateOnly2)
    	{
    		return (aDateOnly1.ToDateTime() > aDateOnly2.ToDateTime());
    	}
    
    	public static bool operator < (DateOnly aDateOnly1, DateOnly aDateOnly2)
    	{
    		return (aDateOnly1.ToDateTime() < aDateOnly2.ToDateTime());
    	}
    
    	public static bool operator >= (DateOnly aDateOnly1, DateOnly aDateOnly2)
    	{
    		return (aDateOnly1.ToDateTime() >= aDateOnly2.ToDateTime());
    	}
    
    	public static bool operator <= (DateOnly aDateOnly1, DateOnly aDateOnly2)
    	{
    		return (aDateOnly1.ToDateTime() <= aDateOnly2.ToDateTime());
    	}
    
    	public static TimeSpan operator - (DateOnly aDateOnly1, DateOnly aDateOnly2)
    	{
    		return (aDateOnly1.ToDateTime() - aDateOnly2.ToDateTime());
    	}
    
    
    	public override string ToString()
    	{
    		return _dateValue.ToShortDateString();
    	}
    
    	public string ToString(string format)
    	{
    		return _dateValue.ToString(format);
    	}
    
    	public string ToString(string fmt, IFormatProvider provider)
    	{
    		return string.Format("{0:" + fmt + "}", _dateValue);
    	}
    
    	public string ToShortDateString()
    	{
    		return _dateValue.ToShortDateString();
    	}
    
    	public string ToDbFormat()
    	{
    		return string.Format("{0:yyyy-MM-dd}", _dateValue);
    	}
    }
