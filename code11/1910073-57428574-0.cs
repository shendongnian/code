csharp
internal static class DoubleAssertion
{
    const Double delta = 0.00001;
    public static void Equal(Double expected, Double actual, String message = null)
    {
        if (Math.Abs(expected - actual) > delta)
        {
            var deltaMessage = $"Expected a difference no greater than <{delta.ToString(CultureInfo.CurrentCulture.NumberFormat)}>";
            if (!String.IsNullOrWhiteSpace(message))
                message = message + Environment.NewLine + deltaMessage;
            else
                message = deltaMessage;
            throw new DoubleException(
                expected: expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                actual: actual.ToString(CultureInfo.CurrentCulture.NumberFormat),
                message: message);
        }
    }
}
public class DoubleException : AssertActualExpectedException
{
    public DoubleException(
        String expected,
        String actual,
        String message)
        : base(expected, actual, message)
    {
    }
}
