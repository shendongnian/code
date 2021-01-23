    <system.serviceModel>
      <client><!--(3)-->
        <endpoint ...YourEndpointConfig... behaviorConfiguration="UserNamePasswordBehavior" />
      </client>
      <behaviors><!--(2)-->
        <endpointBehaviors>
          <behavior name="UserNamePasswordBehavior">
            <userNameClientCredentials userName="skroob" password="12345" />
            <!--Visual Studio will give you warning squiggly on <userNameClientCredentials>
                saying that "The element 'behavior' has invalid child element" 
                but will work at runtime.-->
          </behavior>
        </endpointBehaviors>
      </behaviors>
      <extensions><!--(1)-->
        <behaviorExtensions>
          <add name="userNameClientCredentials" type="MyNamespace.UserNameClientCredentialsElement, MyAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
        </behaviorExtensions>
      </extensions>
      ...
    </system.serviceModel>
