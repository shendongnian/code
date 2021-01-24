    <RadioButton x:Name="RadioButton" ToolTipService.ShowOnDisabled="True" 
                         DataContext="{Binding ViewModel, RelativeSource={RelativeSource AncestorType={x:Type local:MainWindow}}}"
                IsEnabled="{Binding IsRadioButtonEnabled}" VerticalAlignment="Center" HorizontalAlignment="Center" Content="Radio">
                <RadioButton.ToolTip>
                    <ToolTip>
                        <TextBlock>
                            <TextBlock.Text>
                                <MultiBinding Converter="{StaticResource BooleanToStringConverter}">
                                    <Binding Path="IsRadioButtonEnabled"/>
                                    <Binding Path="EnabledToolTip"/>
                                    <Binding Path="DisabledToolTip"/>
                                </MultiBinding>
                            </TextBlock.Text>
                        </TextBlock>
                    </ToolTip>
                </RadioButton.ToolTip>
            </RadioButton>
