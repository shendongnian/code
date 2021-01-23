    <system.web>
        <membership defaultProvider="MembeshipProvider">
          <providers>
            <clear/>
            <add connectionStringName="Test" name="MembeshipProvider"
                 type="SqlMembershipProvider" />
          </providers>
        </membership>
        <roleManager enabled="true" defaultProvider="RoleProvider">
          <providers>
            <add connectionStringName="Test" name="RoleProvider" type="System.Web.Security.SqlRoleProvider" />
          </providers>
        </roleManager>
        <profile defaultProvider="ProfileProvider">
          <providers>
            <clear/>
            <add name="ProfileProvider" type="System.Web.Profile.SqlProfileProvider"
                 connectionStringName="Test"/>
          </providers>
          <properties>
            <add name="FirstName" type="System.String"/>
            <add name="LastName" type ="System.String"/>
            <add name="Email" type="System.String"/>
        	.
    	.
    	.
          </properties>
        </profile>
    </system.web>
