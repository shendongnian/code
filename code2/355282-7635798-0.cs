    public class Device
    {
        public string Name;
        public Dictionary<string, Group> Groups = new Dictionary<string, Group>();
    }
    public class Group
    {
        public string Name;
        public List<string> Pins = new List<string>();
    }
    public class QuickFailureReportText
    {
        public Dictionary<string, Device> devices = new Dictionary<string, Device>();
        public void AddLog(string deviceName, string groupName, string pin)
        {
            if (!devices.ContainsKey(deviceName))
                devices.Add(deviceName, new Device() 
                     { Name = deviceName, Groups = new Dictionary<string, Group>() });
            if (!devices[deviceName].Groups.ContainsKey(groupName))
                devices[deviceName].Groups.Add(groupName, new Group() 
                     { Name = groupName, Pins = new List<string>() });
            devices[deviceName].Groups[groupName].Pins.Add(pin);
        }
        public override string ToString()
        {
            TextWriter tw;
            StringBuilder sb = new StringBuilder();
            tw = new StringWriter(sb);
            tw.WriteLine("Quick Failure Report");
            XDocument xDoc = XDocument.Load(@"devices.xml");
            foreach (XElement device in xDoc.XPathSelectElements("DEVICES/device"))
            {
                foreach (XElement group in device.XPathSelectElements("groups/group"))
                {
                    foreach (XElement pin in group.XPathSelectElements("pins/pin"))
                    {
                        if (pin.Attribute("result").Value == "fail")
                        {
                            AddLog(device.XPathSelectElement("name").Value,
                            group.XPathSelectElement("group_name").Value, pin.Value);
                        }
                    }
                }
            }
            foreach (var device in devices.Values)
            {
                tw.WriteLine("Failures in " + device.Name);
                foreach (var grp in device.Groups.Values)
                {
                    tw.Write("Group " + grp.Name + " : ");
                    foreach (string p in grp.Pins)
                    {
                        tw.Write(p + ", ");
                    }
                    tw.WriteLine(); //new line
                }
                tw.WriteLine(); //new line
            }
            return tw.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = new QuickFailureReportText().ToString();
        }
    }
