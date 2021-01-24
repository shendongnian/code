    <Button x:Name="btnExe">
        <Button.Style>
            <Style BasedOn="{StaticResource {x:Type Button}}" TargetType="{x:Type Button}">
                <Setter Property="Content">
                    <Setter.Value>
                        <Image Source="InterruptorOFF.png" />
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self}, Path=Command.IsExecuting}" Value="True">
                        <Setter Property="Content">
                            <Setter.Value>
                                <Image Source="InterruptorON.png" />
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
