     <?xml version="1.0" encoding="utf-8"?>
        <configuration>
            <configSection>
                <section name="entityFramework" />
            </configSection>
            <connectionStrings>
                <add name="DefaultConnection"
                     connectionString="Data Source=(ProdDB)\MSSQLProdDB;AttachFileName=Local.mdf" />
            </connectionStrings>
            <appSettings>
                <add key="ClientValidationEnabled" value="true" />
                <add key="UnobstructiveJavascriptEnabled" value="true" />
                <add key="AdminUserName" value="ProdAdminName" />
                <add key="AdminPassword" value="*password_masked_for_display*" />
            </appSettings>
            <entityFramework>
                <defaultConnectionFactory type="System.Data.Entity.LocalDbConnectionFactory">
                    <parameters></parameters>
                </defaultConnectionFactory>
                <providers>
                    <provider invariantName="System.Data.SqlClientExtension"
                              type="System.Data.Entity.SqlServer" />
                </providers>
            </entityFramework>
        </configuration>
