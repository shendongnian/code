    <autofac defaultAssembly="Autofac.Example.Calculator.Api">
                <components>
                        <component
                                type="Autofac.Example.Calculator.Addition.Add, Autofac.Example.Calculator.Addition"
                                service="Autofac.Example.Calculator.Api.IOperation" />
                        <component
                                type="Autofac.Example.Calculator.Division.Divide, Autofac.Example.Calculator.Division"
                                service="Autofac.Example.Calculator.Api.IOperation" >
                                <parameters>
                                        <parameter name="places" value="4" />
                                </parameters>
                        </component>
