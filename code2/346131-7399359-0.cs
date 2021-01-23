    using System.Configuration;
    
    var strList = new CommaDelimitedStringCollection();
    strList.AddRange(ComboBox1.DataSource.Select(x => x.Name.ToString()));
    var commaListStr = strList.ToString();
