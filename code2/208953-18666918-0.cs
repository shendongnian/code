    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    <configSections>
    <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true"/>
    </configSections>
     
    <system.data>
    <DbProviderFactories>
    <add name="EntLibContrib.Data.MySql"
    invariant="EntLibContrib.Data.MySql"
    description="EntLibContrib Data MySql Provider"
    type="EntLibContrib.Data.MySql.MySqlDatabase, EntLibContrib.Data.MySql, Version=5.0.505.0, Culture=neutral, PublicKeyToken=null" />
    </DbProviderFactories>
    </system.data>
     
    <dataConfiguration defaultDatabase="Default Connection String">
    <providerMappings>
    <add databaseType="EntLibContrib.Data.MySql.MySqlDatabase, EntLibContrib.Data.MySql, Version=5.0.505.0, Culture=neutral, PublicKeyToken=null"
    name="EntLibContrib.Data.MySql"/>
    </providerMappings>
    </dataConfiguration>
     
    <connectionStrings>
    <add name="Default Connection String"
    connectionString="database=northwind;uid=root;pwd=admin"
    providerName="EntLibContrib.Data.MySql"/>
    </connectionStrings>
     
    <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
    </startup>
    </configuration>
     
