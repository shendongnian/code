        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Diagnostics;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Stopwatch sw;
                    string str;
                    sw = Stopwatch.StartNew();
                    for (int i = 0; i < 1000000; i++)
                        str = "Step cannot be zero.".Slice(null, null, -3, true);
                    sw.Stop();
                    Console.WriteLine("LINQ " + sw.Elapsed.TotalSeconds.ToString("0.#######") + " seconds");
                    sw = Stopwatch.StartNew();
                    for (int i = 0; i < 1000000; i++)
                        str = "Step cannot be zero.".Slice(null, null, -3, false);
                    sw.Stop();
                    Console.WriteLine("MANUAL " + sw.Elapsed.TotalSeconds.ToString("0.#######") + " seconds");
                    Console.ReadLine();
                }
            }
           static class  test
            {
                public static string Slice(this string str, int? start, int? end, int step, bool linq)
                {
                    if (step == 0) throw new ArgumentException("Step cannot be zero.", "step");
                    if (linq)
                    {
                    
                        if (start == null) start = 0;
                        else if (start > str.Length) start = str.Length;
                        if (end == null) end = str.Length;
                        else if (end > str.Length) end = str.Length;
                        if (step < 0)
                        {
                            str = new string(str.Reverse().ToArray());
                            step = Math.Abs(step);
                        }
                    }
                    else
                    {
                        if (start == null)
                        {
                            if (step > 0) start = 0;
                            else start = str.Length - 1;
                        }
                        else if (start < 0)
                        {
                            if (start < -str.Length) start = 0;
                            else start += str.Length;
                        }
                        else if (start > str.Length) start = str.Length;
                        if (end == null)
                        {
                            if (step > 0) end = str.Length;
                            else end = -1;
                        }
                        else if (end < 0)
                        {
                            if (end < -str.Length) end = 0;
                            else end += str.Length;
                        }
                        else if (end > str.Length) end = str.Length;
                    }
                    if (start == end || start < end && step < 0 || start > end && step > 0) return "";
                    if (start < end && step == 1) return str.Substring(start.Value, end.Value - start.Value);
                    if (linq)
                    {
                        return new string(str.Skip(start.Value).Take(end.Value - start.Value).Where((s, index) => index % step == 0).ToArray ());;
                    }
                    else
                    {
                        int length = (int)(((end.Value - start.Value) / (float)step) + 0.5f);
                        var sb = new StringBuilder(length);
                        for (int i = start.Value, j = 0; j < length; i += step, ++j)
                            sb.Append(str[i]);
                        return sb.ToString();
                    }
                }
            }
        }
