    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace sbcjc.sei
    {
            public class JsEncoder
            {
                static Regex EncodeLiteralRegex;
    
                // Format a bunch of literals.
                public static string Format (string format, params object[] items)
                {
                    return string.Format(format,
                        items.Select(item => EncodeString("" + item)).ToArray());
                }
    
                // Given a string, return a string suitable for safe
                // use within a Javascript literal inside a <script> block.
                // This approach errs on the side of "ugly" escaping.
                public static string EncodeString (string value)
                {
                    if (EncodeLiteralRegex == null) {
                        // initial accept "space to ~" in ASCII then reject quotes 
                        // and some XML chars (this avoids `</script>`, `<![CDATA[..]]>>`, and XML vs HTML issues)
                        // "/" is not allowed because it requires an escape in JSON
                        var accepted = Enumerable.Range(32, 127 - 32)
                            .Except(new int[] { '"', '\'', '\\', '&', '<', '>', '/' });
                        // pattern matches everything but accepted
                        EncodeLiteralRegex = new Regex("[^" +
                            string.Join("", accepted.Select(c => @"\x" + c.ToString("x2")).ToArray())
                            + "]");
                    }
                    return EncodeLiteralRegex.Replace(value ?? "", (match) =>
                    {
                        var ch = (int)match.Value[0]; // only matches a character at a time
                        return ch <= 127
                            ? @"\x" + ch.ToString("x2") // not JSON
                            : @"\u" + ch.ToString("x4");
                    });
                }
            }
    }
