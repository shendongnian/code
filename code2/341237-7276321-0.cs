    public class StackOverflow_7276178
    {
        const string XML = @"<group name='name1'  >
      <group name='name2'  >
        <image name='test1' >
          <image name='test2' ></image>
          <group name='test98'>
            <image name='test67' >
              <group name='test987'>
                <text name='asddd' path='myPath'></text>
              </group>
            </image>
          </group>
          <group name='name22'  >
            <image name='test3' left='myLeft'></image>
          </group>
        </image>
        <image name='test4'>
          <text name='asddd'></text>
        </image>
      </group>
    </group>";
        public static void Test()
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(XML);
            foreach (XmlAttribute pathAttr in doc.SelectNodes("//@path"))
            {
                pathAttr.Value = pathAttr.Value + "_modified";
            }
            foreach (XmlAttribute leftAttr in doc.SelectNodes("//@left"))
            {
                leftAttr.Value = leftAttr.Value + "_modified";
            }
            Console.WriteLine(doc.OuterXml);
        }
    }
