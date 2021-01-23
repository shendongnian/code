        <Border>
            <Border.Width>
                <MultiBinding Converter="{StaticResource fm2pconv}">
                    <MultiBinding.Bindings>
                        <Binding Path="Factor" Source="{x:Static tc:PPMM.Singleton}" />
                        <Binding>
                            <Binding.Source>
                                <sys:Double>50</sys:Double>
                            </Binding.Source>
                        </Binding>
                        <Binding>
                            <Binding.Source>
                                <sys:Double>400</sys:Double>
                            </Binding.Source>
                        </Binding>
                    </MultiBinding.Bindings>
                </MultiBinding>
            </Border.Width>
            <TextBlock
                Text="Wenn Factor gesetzt ist, ist dieser Kasten 50mm breit. Ansonsten ist er 400px breit. Seine Width wird beeinflusst."
                TextWrapping="WrapWithOverflow"
                >
                
            </TextBlock>
        </Border>
