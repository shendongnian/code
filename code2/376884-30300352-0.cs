    <configuration>
      <configsections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration">
        </section>
      </configsections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <alias alias="IRepository" type="UnityTest.IRepository, UnityTest">
          <alias alias="Repository" type="UnityTest.Repository, UnityTest">
            <container>
              <register mapto="Repository" type="IRepository">
                <register name="MyClass" type="UnityTest.MyClass, UnityTest">
                  <constructor>
                    <param name="repository" type="IRepository">
                    <dependency name="IRepository">
                    </dependency>
                  </constructor>
                </register>
              </register>
            </container>
          </alias>
        </alias>
      </unity>
    </configuration>
