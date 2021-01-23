    /**/
    
    // file="CaseInsensitiveEnumConfigurationValueConverter.cs"
    
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Globalization;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        public class CaseInsensitiveEnumConfigurationValueConverter<T> : ConfigurationConverterBase
        {
            public override object ConvertFrom(ITypeDescriptorContext ctx, CultureInfo ci, object data)
            {
                return Enum.Parse(typeof(T), (string)data, true);
            }
        }
    }
    
    
    /**/
    
    
    // file="UsaCountyCollection.cs"
    
    
    using System.Collections.Generic;
    using System.Configuration;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        [ConfigurationCollection(typeof(UsaCountyConfigurationElement))]
        public class UsaCountyCollection : ConfigurationElementCollection, IEnumerable<UsaCountyConfigurationElement>
        {
            public override ConfigurationElementCollectionType CollectionType
            {
                get { return ConfigurationElementCollectionType.BasicMap; }
            }
    
            protected override string ElementName
            {
                get { return "usaCounty"; }
            }
    
            public UsaCountyConfigurationElement this[int index]
            {
                get { return (UsaCountyConfigurationElement)BaseGet(index); }
            }
    
            public new UsaCountyConfigurationElement this[string name]
            {
                get
                {
                    if (this.IndexOf(name) < 0)
                    {
                        return null;
                    }
    
                    return (UsaCountyConfigurationElement)BaseGet(name);
                }
            }
    
            public void Add(UsaCountyConfigurationElement newItem)
            {
                this.BaseAdd(newItem);
            }
    
            public int IndexOf(string usaCountyValue)
            {
                for (int idx = 0; idx < this.Count; idx++)
                {
                    if (this[idx].UsaCountyValue.ToLower(System.Globalization.CultureInfo.CurrentCulture) == usaCountyValue.ToLower(System.Globalization.CultureInfo.CurrentCulture))
                    {
                        return idx;
                    }
                }
    
                return -1;
            }
    
            public new IEnumerator<UsaCountyConfigurationElement> GetEnumerator()
            {
                int count = this.Count;
    
                for (int i = 0; i < count; i++)
                {
                    yield return this.BaseGet(i) as UsaCountyConfigurationElement;
                }
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new UsaCountyConfigurationElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((UsaCountyConfigurationElement)element).UsaCountyValue;
            }
        }
    }
    
    
    
    /**/
    
    
    
    
    // file="UsaCountyConfigurationElement.cs"
    
    
    
    
    using System.ComponentModel;
    using System.Configuration;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        [System.Diagnostics.DebuggerDisplay("UsaCountyValue='{UsaCountyValue}'")]
        public class UsaCountyConfigurationElement : ConfigurationElement
        {
            private const string UsaCountyValuePropertyName = "usaCountyValue";
    
            public UsaCountyConfigurationElement()
            {
            }
    
            public UsaCountyConfigurationElement(string usaCountyValue)
            {
                this.UsaCountyValue = usaCountyValue;
            }
    
            [ConfigurationProperty(UsaCountyValuePropertyName, IsRequired = true, IsKey = true, DefaultValue = "")]
            [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;’\"|\\")]
            public string UsaCountyValue
            {
                get { return (string)this[UsaCountyValuePropertyName]; }
                set { this[UsaCountyValuePropertyName] = value; }
            }
        }
    }
    
    
    /**/
    
    
    
    
    // file="UsaCountyLabelEnum.cs"
    
    
    
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        public enum UsaCountyLabelEnum
        {
            Unknown,
            County,
            Parish,
            Borough
        }
    }
    
    
    /**/
    
    
    
    
    // file="UsaStateDefinitionCollection.cs"
    
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    
    using GranadaCoder.CustomConfigurationExample.Configuration.Interfaces;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        [ConfigurationCollection(typeof(UsaStateDefinitionConfigurationElement))]
        public class UsaStateDefinitionCollection : ConfigurationElementCollection, IUsaStateDefinitionCollection
        {
            public UsaStateDefinitionCollection()
            {
                UsaStateDefinitionConfigurationElement details = (UsaStateDefinitionConfigurationElement)this.CreateNewElement();
                if (!string.IsNullOrEmpty(details.UsaStateFullName))
                {
                    this.Add(details);
                }
            }
    
            public override ConfigurationElementCollectionType CollectionType
            {
                get
                {
                    return ConfigurationElementCollectionType.BasicMap;
                }
            }
    
            bool ICollection<UsaStateDefinitionConfigurationElement>.IsReadOnly
            {
                get
                {
                    return false;
                }
            }
    
            protected override string ElementName
            {
                get { return "usaStateDefinition"; }
            }
    
            public UsaStateDefinitionConfigurationElement this[int index]
            {
                get
                {
                    return (UsaStateDefinitionConfigurationElement)BaseGet(index);
                }
    
                set
                {
                    if (this.BaseGet(index) != null)
                    {
                        this.BaseRemoveAt(index);
                    }
    
                    this.BaseAdd(index, value);
                }
            }
    
            public new UsaStateDefinitionConfigurationElement this[string name]
            {
                get
                {
                    return (UsaStateDefinitionConfigurationElement)this.BaseGet(name);
                }
            }
    
            public int IndexOf(UsaStateDefinitionConfigurationElement details)
            {
                return this.BaseIndexOf(details);
            }
    
            public void Add(UsaStateDefinitionConfigurationElement newItem)
            {
                this.BaseAdd(newItem);
            }
    
            public bool Remove(UsaStateDefinitionConfigurationElement details)
            {
                if (this.BaseIndexOf(details) >= 0)
                {
                    this.BaseRemove(details.UsaStateFullName);
                    return true;
                }
    
                return false;
            }
    
            public void RemoveAt(int index)
            {
                this.BaseRemoveAt(index);
            }
    
            public void Remove(string name)
            {
                this.BaseRemove(name);
            }
    
            public void Clear()
            {
                this.BaseClear();
            }
    
            public bool Contains(UsaStateDefinitionConfigurationElement item)
            {
                if (this.IndexOf(item) >= 0)
                {
                    return true;
                }
    
                return false;
            }
    
            public void CopyTo(UsaStateDefinitionConfigurationElement[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }
    
            public void Insert(int index, UsaStateDefinitionConfigurationElement item)
            {
                this.BaseAdd(index, item);
            }
    
            public new IEnumerator<UsaStateDefinitionConfigurationElement> GetEnumerator()
            {
                int count = this.Count;
    
                for (int i = 0; i < count; i++)
                {
                    yield return this.BaseGet(i) as UsaStateDefinitionConfigurationElement;
                }
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new UsaStateDefinitionConfigurationElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((UsaStateDefinitionConfigurationElement)element).UsaStateFullName;
            }
    
            protected override void BaseAdd(ConfigurationElement element)
            {
                this.BaseAdd(element, false);
            }
        }
    }
    
    
    /**/
    
    
    
    
    // file="UsaStateDefinitionConfigurationElement.cs"
    
    
    
    
    using System;
    using System.ComponentModel;
    using System.Configuration;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        [System.Diagnostics.DebuggerDisplay("UsaStateFullName = '{UsaStateFullName}'")]
        public class UsaStateDefinitionConfigurationElement : ConfigurationElement
        {
            private const string UsaStateFullNamePropertyName = "usaStateFullName";
            private const string UsaStateAbbreviationPropertyName = "usaStateAbbreviation";
            private const string UsaStateDefinitionUniqueIdentifierPropertyName = "usaStateDefinitionUniqueIdentifier";
            private const string IsContenentialPropertyName = "isContenential";
            private const string CountyLabelNamePropertyName = "countyLabelName";
    
            private const string UsaCountiesPropertyName = "usaCounties";
            private const string ServiceBusQueuesPropertyName = "serviceBusQueues";
    
            [ConfigurationProperty(UsaStateFullNamePropertyName, IsRequired = true, IsKey = true)]
            [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;’\"|\\")]
            public string UsaStateFullName
            {
                get { return (string)this[UsaStateFullNamePropertyName]; }
                set { this[UsaStateFullNamePropertyName] = value; }
            }
    
            [ConfigurationProperty(UsaStateAbbreviationPropertyName, IsRequired = true, IsKey = true)]
            [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
            public string UsaStateAbbreviation
            {
                get { return (string)this[UsaStateAbbreviationPropertyName]; }
                set { this[UsaStateAbbreviationPropertyName] = value; }
            }
    
            [ConfigurationProperty(UsaStateDefinitionUniqueIdentifierPropertyName, IsRequired = true)]
            public int UsaStateDefinitionUniqueIdentifier
            {
                get { return (int)this[UsaStateDefinitionUniqueIdentifierPropertyName]; }
                set { this[UsaStateDefinitionUniqueIdentifierPropertyName] = value; }
            }
           
            [ConfigurationProperty(IsContenentialPropertyName, IsRequired = true)]
            public bool IsContenential
            {
                get { return (bool)this[IsContenentialPropertyName]; }
                set { this[IsContenentialPropertyName] = value; }
            }
    
            [ConfigurationProperty(UsaCountiesPropertyName, IsDefaultCollection = false)]
            public UsaCountyCollection UsaCounties
            {
                get { return (UsaCountyCollection)base[UsaCountiesPropertyName]; }
                set { this[UsaCountiesPropertyName] = value; } /* set is here for UnitTests */
            }
    
            [ConfigurationProperty(CountyLabelNamePropertyName, DefaultValue = UsaCountyLabelEnum.Unknown)]
            [TypeConverter(typeof(CaseInsensitiveEnumConfigurationValueConverter<UsaCountyLabelEnum>))]
            public UsaCountyLabelEnum CountyLabelType
            {
                get
                {
                    return (UsaCountyLabelEnum)this[CountyLabelNamePropertyName];
                }
    
                set
                {
                    base[CountyLabelNamePropertyName] = value;
                }
            }
        }
    }
    
    
    
    /**/
    
    
    
    
    // file="UsaStateDefinitionConfigurationRetriever.cs"
    
    
    
    
    using System;
    using System.Configuration;
    using System.Linq;
    
    using GranadaCoder.CustomConfigurationExample.Configuration.Interfaces;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        public class UsaStateDefinitionConfigurationRetriever : IUsaStateDefinitionConfigurationSectionRetriever
        {
            public static readonly string ConfigurationSectionName = "UsaStateDefinitionConfigurationSectionName";
    
            public IUsaStateDefinitionConfigurationSection GetIUsaStateDefinitionConfigurationSection()
            {
                UsaStateDefinitionConfigurationSection returnSection = (UsaStateDefinitionConfigurationSection)ConfigurationManager.GetSection(ConfigurationSectionName);
                if (returnSection != null)
                {
                    var duplicates = returnSection.IUsaStateDefinitions.GroupBy(i => new { i.UsaStateDefinitionUniqueIdentifier })
                      .Where(g => g.Count() > 1)
                      .Select(g => g.Key);
    
                    if (duplicates.Count() > 1)
                    {
                        throw new ArgumentOutOfRangeException("Duplicate UsaStateDefinitionUniqueIdentifier values.", Convert.ToString(duplicates.First().UsaStateDefinitionUniqueIdentifier));
                    }
    
                    return returnSection;
                }
    
                return null;
            }
        }
    }
    
    
    /**/
    
    
    
    
    // file="UsaStateDefinitionConfigurationSection.cs"
    
    
    
    
    using System.Configuration;
    
    using GranadaCoder.CustomConfigurationExample.Configuration.Interfaces;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        public class UsaStateDefinitionConfigurationSection : ConfigurationSection, IUsaStateDefinitionConfigurationSection
        {
            [ConfigurationProperty("", IsDefaultCollection = true)]
            public UsaStateDefinitionCollection UsaStateDefinitions
            {
                get
                {
                    UsaStateDefinitionCollection coll = (UsaStateDefinitionCollection)base[string.Empty];
                    return coll;
                }
            }
    
            /* Here is the interface property that simply returns the non-interface property from above.  This allows System.Configuration to hydrate the non-interface property, but allows the code to be written (and unit test mocks to be written) against the interface property. */
            public IUsaStateDefinitionCollection IUsaStateDefinitions
            {
                get { return this.UsaStateDefinitions; }
            }
        }
    }
    
    
    
    /**/
    
    
    
    
    // file="UsaStateDefinitionFinder.cs"
    
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    
    using GranadaCoder.CustomConfigurationExample.Configuration.Interfaces;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration
    {
        public class UsaStateDefinitionFinder : IUsaStateDefinitionFinder
        {
            private const string ErrorMessageMoreThanOneMatch = "More than item was found with the selection criteria. ({0})";
    
            private const string ErrorMessageNoMatch = "No item was found with the selection criteria. ({0})";
    
            public UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElement(IUsaStateDefinitionConfigurationSection settings, string usaStateFullName)
            {
                UsaStateDefinitionConfigurationElement returnItem = null;
    
                if (null != settings && null != settings.IUsaStateDefinitions)
                {
                    ICollection<UsaStateDefinitionConfigurationElement> matchingFarmItems;
                    matchingFarmItems = settings.IUsaStateDefinitions.Where(ele => usaStateFullName.Equals(ele.UsaStateFullName, StringComparison.OrdinalIgnoreCase)).ToList();
    
                    if (matchingFarmItems.Count > 1)
                    {
                        string errorDetails = this.BuildErrorDetails(matchingFarmItems);
                        throw new IndexOutOfRangeException(string.Format(ErrorMessageMoreThanOneMatch, errorDetails));
                    }
    
                    returnItem = matchingFarmItems.FirstOrDefault();
                }
    
                return returnItem;
            }
    
            public UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElement(string usaStateFullName)
            {
                IUsaStateDefinitionConfigurationSection settings = new UsaStateDefinitionConfigurationRetriever().GetIUsaStateDefinitionConfigurationSection();
                return this.FindUsaStateDefinitionConfigurationElement(settings, usaStateFullName);
            }
    
            public UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElementByUniqueId(int id)
            {
                IUsaStateDefinitionConfigurationSection settings = new UsaStateDefinitionConfigurationRetriever().GetIUsaStateDefinitionConfigurationSection();
                return this.FindUsaStateDefinitionConfigurationElementByUniqueId(settings, id);
            }
    
            public UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElementByUniqueId(IUsaStateDefinitionConfigurationSection settings, int id)
            {
                UsaStateDefinitionConfigurationElement returnItem = null;
    
                if (null != settings && null != settings.IUsaStateDefinitions)
                {
                    ICollection<UsaStateDefinitionConfigurationElement> matchingFarmItems;
                    matchingFarmItems = settings.IUsaStateDefinitions.Where(ele => id == ele.UsaStateDefinitionUniqueIdentifier).ToList();
    
                    if (matchingFarmItems.Count > 1)
                    {
                        string errorDetails = this.BuildErrorDetails(matchingFarmItems);
                        throw new IndexOutOfRangeException(string.Format(ErrorMessageMoreThanOneMatch, errorDetails));
                    }
    
                    returnItem = matchingFarmItems.FirstOrDefault();
                }
    
                return returnItem;
            }
    
            private string BuildErrorDetails(ICollection<UsaStateDefinitionConfigurationElement> items)
            {
                string returnValue;
    
                StringBuilder sb = new StringBuilder();
    
                if (null != items)
                {
                    foreach (UsaStateDefinitionConfigurationElement item in items)
                    {
                        sb.Append(string.Format("UsaStateFullName='{0}'.", item.UsaStateFullName));
                    }
                }
    
                returnValue = sb.ToString();
    
                return returnValue;
            }
        }
    }
    
    
    
    /**/
    
    
    
    
    // file="IUsaStateDefinitionCollection.cs"
    
    
    
    
    using System;
    using System.Collections.Generic;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration.Interfaces
    {
        public interface IUsaStateDefinitionCollection : IList<UsaStateDefinitionConfigurationElement>, IEnumerable<UsaStateDefinitionConfigurationElement> /* Implement IEnumerable to allow Linq queries */
        {
            UsaStateDefinitionConfigurationElement this[string name] { get; }
    
            void Remove(string name);
        }
    }
    
    
    
    /**/
    
    
    
    
    // file="IUsaStateDefinitionConfigurationSection.cs"
    
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration.Interfaces
    {
        public interface IUsaStateDefinitionConfigurationSection
        {
            IUsaStateDefinitionCollection IUsaStateDefinitions { get; }
        }
    }
    
    
    /**/
    
    
    
    
    // file="IUsaStateDefinitionConfigurationSectionRetriever.cs"
    
    
    
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration.Interfaces
    {
        public interface IUsaStateDefinitionConfigurationSectionRetriever
        {
            IUsaStateDefinitionConfigurationSection GetIUsaStateDefinitionConfigurationSection();
        }
    }
    
    
    
    /**/
    
    
    
    
    // file="IUsaStateDefinitionFinder.cs"
    
    
    
    
    using System;
    
    namespace GranadaCoder.CustomConfigurationExample.Configuration.Interfaces
    {
        public interface IUsaStateDefinitionFinder
        {
            UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElement(IUsaStateDefinitionConfigurationSection settings, string usaStateFullName);
    
            UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElement(string usaStateFullName);
    
            UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElementByUniqueId(int id);
    
            UsaStateDefinitionConfigurationElement FindUsaStateDefinitionConfigurationElementByUniqueId(IUsaStateDefinitionConfigurationSection settings, int id);
      }
    }
    
    
    
    /**/
    
    
    
    
    // file="Program.cs"
    
    using System;
    using System.Text;
    
    using GranadaCoder.CustomConfigurationExample.Configuration;
    using GranadaCoder.CustomConfigurationExample.Configuration.Interfaces;
    
    using log4net;
    using Microsoft.Practices.Unity;
    
    namespace GranadaCoder.CustomConfigurationExample.ConsoleAppOne
    {
        public static class Program
        {
            public const int UnhandledExceptionErrorCode = 1;
    
            private static readonly ILog TheLogger = LogManager.GetLogger(typeof(Program));
    
            public static int Main(string[] args)
            {
                int returnValue = 0;
                string logMsg = string.Empty;
    
                try
                {
                    //// For future //log4net.Config.XmlConfigurator.Configure();
                    //// For future //IUnityContainer container = new UnityContainer();
                    //// For future //container.RegisterType<ILog>(new InjectionFactory(x => LogManager.GetLogger(typeof(GranadaCoder.CustomConfigurationExample.ConsoleAppOne.Program))));
    
                    IUsaStateDefinitionConfigurationSectionRetriever retr = new UsaStateDefinitionConfigurationRetriever();
                    IUsaStateDefinitionConfigurationSection section = retr.GetIUsaStateDefinitionConfigurationSection();
    
                    IUsaStateDefinitionFinder finder = new UsaStateDefinitionFinder();
                    UsaStateDefinitionConfigurationElement foundElement = finder.FindUsaStateDefinitionConfigurationElement("Virginia");
    
                    if (null != section)
                    {
                        foreach (UsaStateDefinitionConfigurationElement state in section.IUsaStateDefinitions)
                        {
                            Console.WriteLine("state.UsaStateFullName='{0}', state.UsaStateAbbreviation='{1}', state.IsContenential='{2}', state.CountyLabelType='{3}'", state.UsaStateFullName, state.UsaStateAbbreviation, state.IsContenential, state.CountyLabelType);
                            foreach (UsaCountyConfigurationElement county in state.UsaCounties)
                            {
                                Console.WriteLine("county.UsaCountyValue='{0}'", county.UsaCountyValue);
                            }
    
                            Console.WriteLine("--------------------");
                        }
                    }
                }
                catch (Exception e)
                {
                    TheLogger.Error(e.Message, e);
                    Console.WriteLine("Unexpected Exception : {0}", e.Message);
                    returnValue = UnhandledExceptionErrorCode;
                }
    
                Console.WriteLine("END : {0}", System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                Console.WriteLine(string.Empty);
    
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
    
                return returnValue;
            }
        }
    }
