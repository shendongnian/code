               /// <summary>
               /// ‘StripBrackets checks that starts from sStart and ends with sEnd (case sensitive).
               ///           ‘If yes, than removes sStart and sEnd.
               ///           ‘Otherwise returns full string unchanges
               ///           ‘See also MidBetween
               /// </summary>
               
               public static string StripBrackets( this string str, string sStart, string sEnd)
              {
                      if (CheckBrackets(str, sStart, sEnd))
                     {
                           str = str.Substring(sStart.Length, (str.Length – sStart.Length) – sEnd.Length);
                     }
                      return str;
              }
               public static bool CheckBrackets( string str, string sStart, string sEnd)
              {
                      bool flag1 = (str != null ) && (str.StartsWith(sStart) && str.EndsWith(sEnd));
                      return flag1;
              }
