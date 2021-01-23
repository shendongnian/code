    using System;
    using System.Configuration ;
    using System.Globalization ;
    using System.Collections.Generic ;
    using System.Text;
    namespace TestDrive
    {
        class Program
        {
            static void Main()
            {
                string src = "foo \uABC123 bar" ;
                string converted = HtmlEncode(src) ;
                return ;
            }
            static string HtmlEncode( string s )
            {
                //
                // In the .Net world, strings are UTF-16 encoded. That means that Unicode codepoints greater than 0x007F
                // are encoded in the string as 2-character digraphs. So to properly turn them into HTML numeric
                // characeter references (decimal or hex), we first need to get the UTF-32 encoding.
                //
                uint[]        utf32Chars = StringToArrayOfUtf32Chars( s ) ;
                StringBuilder sb         = new StringBuilder( 2000 ) ; // set a reasonable initial size for the buffer
                // iterate over the utf-32 encoded characters
                foreach ( uint codePoint in utf32Chars )
                {
                    if ( codePoint > 0x0000007F )
                    {
                        // if the code point is greater than 0x7F, it gets turned into an HTML numerica character reference
                        sb.AppendFormat( "&#x{0:X};" , codePoint ) ; // hex escape sequence
                      //sb.AppendFormat( "&#{0};"    , codePoint ) ; // decimal escape sequence
                    }
                    else
                    {
                        // if less than or equal to 0x7F, it goes into the string as-is,
                        // except for the 5 SGML/XML/HTML reserved characters. You might
                        // want to also escape all the ASCII control characters (those chars
                        // in the range 0x00 - 0x1F).
                        // convert the unit to an UTF-16 character
                        char ch = Convert.ToChar( codePoint ) ;
                        // do the needful.
                        switch ( ch )
                        {
                        case '"'  : sb.Append( "&quot;"      ) ; break ;
                        case '\'' : sb.Append( "&apos;"      ) ; break ;
                        case '&'  : sb.Append( "&amp;"       ) ; break ;
                        case '<'  : sb.Append( "&lt;"        ) ; break ;
                        case '>'  : sb.Append( "&gt;"        ) ; break ;
                        default   : sb.Append( ch.ToString() ) ; break ;
                        }
                    }
                }
                // return the escaped, utf-16 string back to the caller.
                string encoded = sb.ToString() ;
                return encoded ;
            }
            /// <summary>
            /// Convert a UTF-16 encoded .Net string into an array of UTF-32 encoding Unicode chars
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            private static uint[] StringToArrayOfUtf32Chars( string s )
            {
                Byte[] bytes      = Encoding.UTF32.GetBytes( s ) ;
                uint[] utf32Chars = (uint[]) Array.CreateInstance( typeof(uint) , bytes.Length / sizeof(uint) ) ;
                for ( int i = 0 , j = 0 ; i < bytes.Length ; i += 4 , ++j )
                {
                    utf32Chars[ j ] = BitConverter.ToUInt32( bytes , i ) ;
                }
                return utf32Chars ;
            }
        }
    }
