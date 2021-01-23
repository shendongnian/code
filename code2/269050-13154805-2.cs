    using System.Linq;
    using System.Text;
    using System.Globalization;
    
    // namespace here
    public static class Utility
    {
        public static string RemoveDiacritics(this string str)
        {
            if (str == null) return null;
            var chars =
                from c in str.Normalize(NormalizationForm.FormD).ToCharArray()
                let uc = CharUnicodeInfo.GetUnicodeCategory(c)
                where uc != UnicodeCategory.NonSpacingMark
                select c;
    
            var cleanStr = new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
             
            return cleanStr;
        }
    }
