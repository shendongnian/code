    public class MyCustomConfig : ConfigurationSectionGroup
    {
        [ConfigurationProperty("[Name].ConfigSection")]
        public objectFeedImport
        {
            get { return base.Sections["[Name].ConfigSection"]; }
        }
    }
    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
    fileMap.ExeConfigFilename = [Custom Config Name];            
    ConfigurationManager.OpenMappedExeConfiguration(fileMap , ConfigurationUserLevel.PerUserRoamingAndLocal)
     <configSections>
        <sectionGroup name="[Name].ConfigGroup" type ="">
           <section name="[Name].ConfigSection" type="" />
         </sectionGroup>
     </configSections>
