            <Button Command="{Binding SomeButtonCommand}" Content="Click Me!">
            <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=NormalButtonMode, Mode=OneWay}" Value="True">
                            <Setter Property="Content" Value="This Button is in Normal Mode" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Path=NormalButtonMode, Mode=OneWay}" Value="False">
                            <Setter Property="Content" Value="This Button is in the Other Mode" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
