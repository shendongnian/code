    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <sectionGroup name="applicationSettings"
                      type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
          
          <!--This section declaratrion pasted here from dll conifg file -->
          <section name="ClassLibrary1.Properties.Settings"
                   type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                   requirePermission="false" />
          <!--This section declaratrion was here in the first place -->
          <section name="MainAssembly.Properties.Settings"
                   type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                   requirePermission="false" />
        </sectionGroup>
      </configSections>
      <connectionStrings>
        <!--This connection string was here in the first place -->
        <add name="MainAssembly.Properties.Settings.MainAssemblyConnectionString"
             connectionString="MainConnectionStringValue" />
        <!--This connection string pasted here from dll config file -->
        <add name="ClassLibrary1.Properties.Settings.LibraryConnectionString"
             connectionString="LibraryConnectionStringValue"
             providerName="" />
      </connectionStrings>
      <applicationSettings>
        <!--This settings section pasted here from dll config file -->
        <ClassLibrary1.Properties.Settings>
          <setting name="LibrarySetting"
                   serializeAs="String">
            <value>LibrarySettingValue</value>
          </setting>
        </ClassLibrary1.Properties.Settings>
        <!--This strings section was here in the first place -->
        <MainAssembly.Properties.Settings>
          <setting name="MainAssemblySetting"
                   serializeAs="String">
            <value>MainSettingValue</value>
          </setting>
        </MainAssembly.Properties.Settings>
      </applicationSettings>
    </configuration>
