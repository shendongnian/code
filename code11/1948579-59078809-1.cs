lang-c#
private string _timeOne;
private string _timeTwo;
public string TimeOne
{
    get { return _timeOne; }
    set
    {
        TimeCheck();
        _timeOne = value;
    }
}
public string TimeTwo
{
    get { return _timeTwo; }
    set
    {
        TimeCheck();
        _timeTwo = value;
}
With your current implementation, each time you say `TimeOne = value;` the setter is being called again, which calls it again, and so on.
**EDIT**
I agree that `TimeCheck()` should not be called in the setters. Instead, I think it would be more appropriate to validate those values, and reset them if necessary, elsewhere. Maybe in a service of some sort, or whatever code is setting those properties to begin with.
