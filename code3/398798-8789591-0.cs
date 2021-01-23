    public abstract class SettingAbstract
    {
       public abstract List<Setting> Children {get;set;}
       public abstract List<object>  Values {get;set}
       public XmlNode SaveMe();
    }
