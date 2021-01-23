    <configuration>
      <!-- section definitions for all elements in <configuration> tag -->
      <configSections>
        <!-- section group, meaning: there will be a <applicationSettings> tag in you configuration-->
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <!-- defines that there will be a <appname.Properties.Settings> tag inside your <applicationSettings> tag -->
          <section name="appname.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </sectionGroup>
      </configSections>
      <applicationSettings>
        <appname.Properties.Settings>
          <!-- name of the property you want to override -->
          <setting name="setting1" serializeAs="String">
            <!-- new value -->
            <value>new string value</value>
          </setting>
        </appname.Properties.Settings>
      </applicationSettings>
    </configuration>
