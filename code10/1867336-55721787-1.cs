    <Button Command="{Binding StartStreamCommand}"
                        IsEnabled="{Binding ElementName=ti_stream, Path=IsSelected}"
                        ToolTip="{x:Static properties:Resources.tt_start}">
        <Button.Style>
            <Style BasedOn="{StaticResource {x:Static ToolBar.ButtonStyleKey}}"
                               TargetType="{x:Type Button}">
                <Setter Property="Visibility">
                    <Setter.Value>
                        <Binding Path="Status" Converter="{StaticResource EnumOrConverter}">
                            <Binding.ConverterParameter>
                                <x:Array Type="{x:Type comm:DeviceStatus}">
                                    <x:Static Member="comm:DeviceStatus.Standby" />
                                    <x:Static Member="comm:DeviceStatus.Busy" />
                                    <x:Static Member="comm:DeviceStatus.Offline" />
                                    <x:Static Member="comm:DeviceStatus.StartingStream" />
                                    <x:Static Member="comm:DeviceStatus.Connecting" />
                                    <x:Static Member="comm:DeviceStatus.Disconnecting" />
                                    <x:Static Member="comm:DeviceStatus.DownloadingFiles" />
                                    </x:Array>
                            </Binding.ConverterParameter>
                        </Binding>
                    </Setter.Value>
                </Setter>
            </Style>
        </Button.Style>
    </Button>
