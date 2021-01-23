    using System;
    using System.Text;
    
    namespace SO_Console_test
    {
        static class ConversionStringExtensions
        {
            //this is going to be a simple example you can 
            //fancy it up a lot...
            public static double ImperialToMetric(this string val)
            {
                /*
                 * With these inputst we want to total inches.
                 * to do this we want to standardize the feet designator to 'f' 
                 * and remove the inch designator altogether.
                    6 inches
                    6in
                    6”
                    4 feet 2 inches
                    4’2”
                    4 ‘ 2 “
                    3 feet
                    3’
                    3 ‘
                    3ft
                    3ft10in
                    3ft 13in (should convert to 4’1”) ...no, should convert to 49 inches, then to metric.
                 */
    
                //make the input lower case and remove blanks:
                val = val.ToLower().Replace(" ", string.Empty);
    
                //make all of the 'normal' feet designators to "ft"
                string S = val.Replace("\'", "f").Replace("feet", "f").Replace("ft", "f").Replace("foot", "f").Replace("‘", "f").Replace("’", "f");
    
                //and remove any inch designator
                S = S.Replace("\"", string.Empty).Replace("inches", string.Empty).Replace("inch", string.Empty).Replace("in", string.Empty).Replace("“", string.Empty).Replace("”", string.Empty);
                		
                //finally we have to be certain we have a number of feet, even if that number is zero
                S = S.IndexOf('f') > 0 ? S : "0f" + S;
                
                //now, any of the inputs above will have been converted to a string 
                //that looks like 4 feet 2 inches => 4f2
    
                string[] values = S.Split('f'); 
                
                int inches = 0;
                //as long as this produces one or two values we are 'on track' 
                if (values.Length < 3)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        inches += values[i] != null && values[i] != string.Empty ? int.Parse(values[i]) * (i == 0 ? 12 : 1) : 0 ;
                    }
                }
    
                //now inches = total number of inches in the input string.
    
                double result = inches * 25.4;
    
                return result;
    
            }
        }
    }
