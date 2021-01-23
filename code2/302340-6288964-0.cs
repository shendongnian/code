    public interface IFormatChecker
    {
        bool CheckFormat(int row, int col, ref string text);
    }
    public sealed class CheckFormatByDelegate : IFormatChecker
    {
        ...
    }
    public class FCS
    {
        public static readonly IFormatChecker FormatDigitsOnly = new CheckFormatByDelegate();
    }
    <mui:DXCell CheckFormat="{x:Static mui:FCS.FormatDigitsOnly}"/>
