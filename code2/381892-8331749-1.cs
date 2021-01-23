    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace XMLUtils
    {
        class Standards
        {
            /// <summary>
            /// Strips non-printable ascii characters 
            /// Refer to http://www.w3.org/TR/xml11/#charsets for XML 1.1
            /// Refer to http://www.w3.org/TR/2006/REC-xml-20060816/#charsets for XML 1.0
            /// </summary>
            /// <param name="content">contents</param>
            /// <param name="XMLVersion">XML Specification to use. Can be 1.0 or 1.1</param>
            private void StripIllegalXMLChars(string tmpContents, string XMLVersion)
            {    
                string pattern = String.Empty;
                switch (XMLVersion)
                {
                    case "1.0":
                        pattern = @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|7F|8[0-46-9A-F]9[0-9A-F])";
                        break;
                    case "1.1":
                        pattern = @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|[19][0-9A-F]|7F|8[0-46-9A-F]|0?[1-8BCEF])";
                        break;
                    default:
                        throw new Exception("Error: Invalid XML Version!");
                }
    
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(tmpContents))
                {
                    tmpContents = regex.Replace(tmpContents, String.Empty);
                }
                tmpContents = string.Empty;
            }
        }
    }
