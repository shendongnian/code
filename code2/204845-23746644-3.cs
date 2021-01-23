    <configuration>
        <system.data>
            <DbProviderFactories>
              <remove invariant="Oracle.DataAccess.Client" />
              <remove invariant="Oracle.ManagedDataAccess.Client" />
              <add name="ODP.NET, Managed Driver"
                   invariant="Oracle.ManagedDataAccess.Client"
                   description="Oracle Data Provider for .NET, Managed Driver"
                   type="Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess, Version=4.121.1.0, Culture=neutral, PublicKeyToken=89b483f429c47342"/>
            </DbProviderFactories>
          </system.data>
    <configuration>
