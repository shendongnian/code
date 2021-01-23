    public class MyCustomConfig : ConfigurationSectionGroup
    {
        [ConfigurationProperty("[Name].ConfigSection")]
        public objectFeedImport
        {
            get { return base.Sections["[Name].ConfigSection"]; }
        }
    }
     <configSections>
        <sectionGroup name="[Name].ConfigGroup" type ="">
           <section name="[Name].ConfigSection" type="" />
         </sectionGroup>
     </configSections>
