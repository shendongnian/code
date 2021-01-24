    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Drawing;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string peaks = (string)doc.Element("peaks");
                byte[] data = Convert.FromBase64String(peaks);
                Single[] number = data.Select((x, i) => new { num = x, index = i }).GroupBy(x => x.index / 4).Select(x => BitConverter.ToSingle(x.Select(y => y.num).ToArray(), 0)).ToArray();
                PointF[] points = number.Select((x, i) => new { num = x, index = i }).GroupBy(x => x.index / 2).Select(x => new PointF(x.First().num, x.Last().num)).ToArray();
            }
        }
    }
