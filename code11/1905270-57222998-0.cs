`
public class Example
{
    private DateTime? _birthdate;
    private Date? _birthdateandmonth;
    public DateTime? Birthdate
    {
        get => _birthdate;
        set
        {
            _birthdate = value;
            _birthdateAndMonth = null;
        }
    }
    public Date? BirthDayAndMonth
    {
        get
        {
            if (!_birthdate.HasValue)
                return null;
            if (!_birthdateandmonth.HasValue)
                _birthdateandmonth = GetAnnualBirthday(Birthdate.Value.Month, Birthdate.Value.Day);
            return _birthdateandmonth;
        }
    }
}
