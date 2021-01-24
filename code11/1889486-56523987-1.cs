    <DatePicker x:Name="dpPicker">
        <DatePicker.CalendarStyle>
            <Style TargetType="Calendar">
                <Setter Property="CalendarDayButtonStyle">
                    <Setter.Value>
                        <Style TargetType="CalendarDayButton">
                            <Style.Resources>
                                <local:DateToBoolConverter x:Key="DateToBoolConverter" />
                            </Style.Resources>
                            <Setter Property="IsHitTestVisible" Value="False" />
                            <Setter Property="Opacity" Value="0.5" />
                            <Style.Triggers>
                                <DataTrigger Value="True">
                                    <DataTrigger.Binding>
                                        <MultiBinding Converter="{StaticResource DateToBoolConverter}">
                                            <Binding Path="Tag" RelativeSource="{RelativeSource AncestorType=DatePicker}" />
                                            <Binding Path="." />
                                        </MultiBinding>
                                    </DataTrigger.Binding>
                                    <Setter Property="IsHitTestVisible" Value="True" />
                                    <Setter Property="Opacity" Value="1" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </Setter.Value>
                </Setter>
            </Style>
        </DatePicker.CalendarStyle>
    </DatePicker>
