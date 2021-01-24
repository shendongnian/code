using System.Text;
namespace CtrlCharReplace
{
    public static class Extensions
    {
        public static string ReplaceCtrl(this string s)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                var isCtrl = char.IsControl(c);
                var n = char.ConvertToUtf32(s, i);
                if (isCtrl)
                {
                    sb.Append($"\\u{n:X4}");
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
