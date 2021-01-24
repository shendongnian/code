    public class MarketingAllCardholder{
        public MarketingAllCardholderData[] marketingAllCardholderDataList { get; set; }
    }
    using System.IO;
    using System.Xml.Serialization;
    using (FileStream fs = new FileStream(@"name.xml", FileMode.Open))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MarketingAllCardholde[]));
        var data = (MarketingAllCardholder[])serializer.Deserialize(fs);
        List<string> list = new List<string>();
        foreach (var item in data)
        {
            //Add All the necessary columns here...
            //After the columns add the delimiter character -> string.Join(","....
        }
        File.WriteAllLines("D:\\csvFile.csv", list);
    }
