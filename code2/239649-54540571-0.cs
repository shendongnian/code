    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    public static class StringExtensions
    {
        public static string ShuffleByTextElements(this string source, Random random)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (random == null) throw new ArgumentNullException(nameof(random));
            var info = new StringInfo(source);
            var indices = Enumerable.Range(0, info.LengthInTextElements).ToArray();
            // Fisher-Yates shuffle
            for (var i = indices.Length; i-- > 1;)
            {
                var j = random.Next(i + 1);
                if (i != j)
                {
                    var temp = indices[i];
                    indices[i] = indices[j];
                    indices[j] = temp;
                }
            }
            var builder = new StringBuilder(source.Length);
            foreach (var index in indices)
            {
                builder.Append(info.SubstringByTextElements(index, 1));
            }
            return builder.ToString();
        }
    }
