    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Globalization;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                //line per line...
                File.WriteAllLines
                    (
                        @"C:\temp\output.txt",
                        ChangeLines(File.ReadLines(@"C:\temp\input.txt"),
                                    line =>
                                    LineOperation3
                                        (
                                            LineOperation2
                                                (
                                                    LineOperation1(line)
                                                )
                                        )
                            )
                    );
                //lines per lines...
                File.WriteAllLines
                   (
                       @"C:\temp\output2WithCount.txt",
                       ChangeLines(File.ReadLines(@"C:\temp\input.txt"),
                                   lines =>
                                            LinesCountOperation
                                            (
                                                LinesCountOperation
                                                (
                                                    LinesCountOperation(lines,LineOperation1),
                                                    LineOperation2
                                                )
                                                , LineOperation3
                                              )
                           )
                   );
            }
            private static IEnumerable<string> ChangeLines(IEnumerable<string> lines, Func<string, string> lineFunc)
            {
                foreach (var line in lines)
                {
                    yield return lineFunc(line);
                }
            }
            private static IEnumerable<string> ChangeLines(IEnumerable<string> lines, Func<IEnumerable<string>, IEnumerable<string>> linesFunc)
            {
                foreach(var changedLine in linesFunc(lines))
                {
                    if (changedLine != null)
                    {
                        yield return changedLine;
                    }
                }
            }
            private static IEnumerable<string> LinesCountOperation(IEnumerable<string> lines, Func<string, string> lineFunc)
            {
                var readAllLines = lines.ToArray();
                var linesCount = readAllLines.Count();
                foreach (var line in readAllLines)
                {
                    var changedLine = lineFunc(line);
                    if (changedLine == null)
                    {
                        continue;
                    }
                    yield return string.Format(CultureInfo.InvariantCulture, "{0}-{1}", linesCount, changedLine);
                }
            }
            private static string LineOperation1(string line)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", line, "1");
            }
            private static string LineOperation2(string line)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", line, "2");
            }
            private static string LineOperation3(string line)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", line, "3");
            }
        }
    }
