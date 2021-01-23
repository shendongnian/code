    /// <summary>
    ///     ALlows persisting of a simple DateTime collection.
    /// </summary>
    [ComplexType]
    public class PersistableDateTimeCollection : PersistableScalarCollection<DateTime>
    {
        protected override DateTime ConvertSingleValueToRuntime(string rawValue)
        {
            return DateTime.Parse(rawValue);
        }
        protected override string ConvertSingleValueToPersistable(DateTime value)
        {
            return value.ToShortDateString();
        }
    }
