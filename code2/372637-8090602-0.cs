    private XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<MySaveItems>));
    private void SerializeToFile()
    {
        using (MemoryStream ms = new MemoryStream(5 * 1024))
        {
            List<MySaveItems> mySaveItemses = new List<MySaveItems>();
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                MySaveItems mySaveItem = new MySaveItems();
                mySaveItem.name = item.Name;
                mySaveItem.text = item.Text;
                mySaveItemses.Add(mySaveItem);
            }
            xmlSerializer.Serialize(ms, mySaveItemses);
            File.WriteAllBytes("c:\\ToolStripItems.xml", ms.ToArray());
        }
    }
    
    private void DeserializeFromFile()
    {
        using (StreamReader ms = new StreamReader("c:\\ToolStripItems.xml"))
        {
            List<MySaveItems> mySaveItemses;
            mySaveItemses = (List<MySaveItems>)xmlSerializer.Deserialize(ms);
        }
    }
    
    [Serializable]
    public class MySaveItems
    {
        public MySaveItems()
        {
        }
        [XmlElement]
        public string name { get; set; }
        [XmlElement]
        public string text { get; set; }
    }
