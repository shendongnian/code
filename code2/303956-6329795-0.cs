    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    namespace SO6329015
    {
        class Program
        {
            static void Main()
            {
                string input = @"DECL E6POS XJV_MOVE_3={X 3887.44,Y 0.00,Z 2594.00, A 0.00, B 90.00, C 180.00,S 22,T 18,E1 2654.30,E2 0.0,E3 0.0,E4 0.0,E5 0.0,E6 0.0 } DECL E6POS XAX749_55_2654_3155075={X 4016.8440,Y -774.9973,Z 1437.1283, A 90.0000, B -45.0000, C -90.0000,S 22,T 26,E1 2654.3000,E2 0.0,E3 0.0,E4 0.0,E5 0.0,E6 0.0 } DECL E6POS XAX755_55_2654_3155075={X 4016.8440,Y -810.9183,Z 1473.0493, A 90.0000, B -45.0000, C -90.0000,S 22,T 26,E1 2654.3000,E2 0.0,E3 0.0,E4 0.0,E5 0.0,E6 0.0 } DECL FDAT FAX755_55_2654_3155075={TOOL_NO 1, BASE_NO 0, IPO_FRAME #BASE, POINT2[] "" ""} DECL LDAT LAX755_55_2654_3155075={ VEL 2.0,ACC 88.0, APO_DIST 100.0, APO_FAC 50.0, ORI_TYP #VAR} ;FOLD From Line 1411";
                const string regex = @"((E6POS [\w]*={)X\s([\d.-]*)\s*,*Y\s*([-.\d]*)\s*,Z\s*([-\d.]*))";
                const string shiftX = "7777";
                const string shiftY = "8888";
                const string shiftZ = "9999";
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
           
                Regex r = new Regex(regex, RegexOptions.IgnoreCase);
                Match m = r.Match(input);
                while (m.Success)
                {
                    try
                    {
                        var xf = Convert.ToDecimal(m.Groups[3].ToString()) + Convert.ToDecimal(shiftX);
                        var yf = Convert.ToDecimal(m.Groups[4].ToString()) + Convert.ToDecimal(shiftY);
                        var zf = Convert.ToDecimal(m.Groups[5].ToString()) + Convert.ToDecimal(shiftZ);
                        input = input.Replace(m.Groups[0].ToString(), string.Format("{0} X {1},Y {2}, Z {3}", m.Groups[2], xf, yf, zf));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        m = m.NextMatch();
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("{0}ms", stopwatch.ElapsedMilliseconds);
                Console.WriteLine(input);
            
            }
        }
    }
