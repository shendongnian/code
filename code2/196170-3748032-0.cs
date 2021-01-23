      <configSections>
        <section name="hibernate-configuration"
                 type="NHibernate.Cfg.ConfigurationSectionHandler, NHibernate"
                 requirePermission="false"/>
        <section name="nhibernate"
                 type="System.Configuration.NameValueSectionHandler, System, Version=1.0.5000.0,Culture=neutral, PublicKeyToken=b77a5c561934e089"
                 requirePermission="false"/>
      </configSections>
    
      <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
        <session-factory>
          <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
          <property name="dialect">NHibernate.Dialect.MySQLDialect</property>
          <property name="connection.driver_class">NHibernate.Driver.MySqlDataDriver</property>
          <property name="connection.connection_string">blahblah</property>
          </session-factory>
      </hibernate-configuration>
    
      <nhibernate>
        <add key="hibernate.use_reflection_optimizer" value="false" />
      </nhibernate>
