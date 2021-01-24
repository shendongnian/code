    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApp22
    {
    
        public class Space
        {
            public long space_id { get; set; }
            public string space_name { get; set; }
            public string formal_name { get; set; }
            public long partition_id { get; set; }
            public DateTime last_mod { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var xml = @"
    <r25:spaces xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xl=""http://www.w3.org/1999/xlink"" xmlns:r25=""http://www.collegenet.com/r25"" pubdate=""2019-07-15T14:51:16-07:00"" engine=""accl"">
      <r25:space crc=""00000022"" status=""est"" xl:href=""space.xml?space_id=200"">
        <r25:space_id>200</r25:space_id>
        <r25:space_name>LRN 0001</r25:space_name>
        <r25:formal_name>Learning Commons -Test Scheduling Room</r25:formal_name>
        <r25:partition_id xl:href=""rmpart.xml?partition_id=2"">2</r25:partition_id>
        <r25:last_mod_dt>2019-07-11T08:01:00-07:00</r25:last_mod_dt>
      </r25:space>
    </r25:spaces>
    ";
                var doc = XDocument.Parse(xml);
                XNamespace ns = "http://www.collegenet.com/r25";
    
                var q = from e in doc.Element(ns + "spaces").Elements()
                        select new Space
                        {
                            space_id = (int)e.Element(ns + "space_id"),
                            space_name = (string)e.Element(ns + "space_name"),
                            formal_name = (string)e.Element(ns + "formal_name"),
                            partition_id = (long)e.Element(ns + "partition_id"),
                            last_mod = (DateTime)e.Element(ns + "last_mod_dt")
                        };
    
                var space = q.First();
            }
        }
    }
