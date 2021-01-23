    <?xml version="1.0"?>
    <configuration>
        <configSections>
            <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
        </configSections>
        <unity>
            <containers>
                <container>
                    <types>
                        <type type="[Namespace].ILogger, [AssemblyName]" mapTo="[Namespace].SomeLogger, [AssemblyName]">
                            <constructor>
                                <param name="test">
                                    <value value="MyDesiredValue" />
                                </param>
                            </constructor>
                        </type>
                    </types>
                </container>
            </containers>
      </unity>
    </configuration>
