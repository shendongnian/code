    /// <summary>
    /// Depending on the complexity of the Xml structure, a complex statemachine could be required here.
    /// Such a reader nicely separates the structure of the Xml from the business logic dependent on the data in the Xml. 
    /// </summary>
    public class CustomXmlReader: XmlWrappingReader
    {
        public CustomXmlReader(XmlReader xmlReader)
            :base(XmlReader.Create(xmlReader, xmlReader.Settings))
        {
        }
        public override bool Read()
        {
            var b = base.Read();
            if (!b)
                return false;
            _myEnum = MyEnum.None;
            if("name".Equals(this.Name))
            {
                _myEnum = MyEnum.Name;
                //custom logic to read the entire element and set the enum, name and any other properties relevant to your domain
                //Use base.Read() until you've read the complete "logical" chunk of Xml. The "logical" chunk could be more than a element.
            }
            if("value".Equals(this.Value))
            {
                _myEnum = Xml.MyEnum.Value;
                //custom logic to read the entire element and set the enum, value and and any other properties relevant to your domain
                //Use base.Read() until you've read the complete "logical" chunk of Xml. The "logical" chunk could be more than a element.
            }
            return true;
        }
        //These properties could return some domain specific values
        #region domain specific reader properties. 
        private MyEnum _myEnum;
        public MyEnum MyEnum
        {
            get { return _myEnum; }
        }
        #endregion
    }
    public enum MyEnum
    {
        Name,
        Value,
        None
    }
    public class MyBusinessAppClass
    {
        public void DoSomething(XmlReader passedInReader)
        {
            var myReader = new CustomXmlReader(passedInReader);
             while(myReader.Read())
             {
                 switch(myReader.MyEnum)
                 {
                     case MyEnum.Name:
                         //Do something here;
                         break;
                     case MyEnum.Value:
                         //Do something here;
                         break;
                 }
             }
        }
    }
