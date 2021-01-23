    using System;
    using System.Web;
    using System.Xml;
    using System.Configuration;
    
    namespace MyConfig
    {
       public enum LevelSetting
       {
          High,
          Medium,
          Low,
          None
       }
       public class MyConfigSectionHandler : IConfigurationSectionHandler
       {
          public virtual object Create(object parent,object configContext,XmlNode section)
          {
             int iLevel = 0;
             string sName = "";
    		
             ConfigHelper.GetEnumValue(section, "level", typeof(LevelSetting), ref iLevel);
             ConfigHelper.GetStringValue(section,"name",ref sName);
             return new MyConfigSection((LevelSetting)iLevel,sName);
          }
       }
       public class MyConfigSection
       {
          private LevelSetting level = LevelSetting.None;
          private string name = null;
          
          public MyConfigSection(LevelSetting _level,string _name)
          {
             level = _level;
             name = _name;
          }
          public LevelSetting Level
          {
             get {return level;}
          }
          public string Name
          {
             get {return name;}
          }
       }
       internal class ConfigHelper
       {
          public static XmlNode GetEnumValue
          (XmlNode _node, string _attribute,Type _enumType, ref int _val)
          {
             XmlNode a = _node.Attributes.RemoveNamedItem(_attribute);
             if(a==null)
                throw new ConfigurationException("Attribute required: " + _attribute);
             if(Enum.IsDefined(_enumType, a.Value))
                _val = (int)Enum.Parse(_enumType,a.Value);
             else
                throw new ConfigurationException("Invalid Level",a);
             return a;
          }
          public static XmlNode GetStringValue(XmlNode _node, string _attribute, ref string _val)
          {
             XmlNode a = _node.Attributes.RemoveNamedItem(_attribute);
             if(a==null)
                throw new ConfigurationException("Attribute required: " + _attribute);
             else
                _val = a.Value;
             return a;		
          }
       }
    }
