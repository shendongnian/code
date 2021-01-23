    <Button Content="ABC"> 
            <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="LayoutTransform" >
                                <Setter.Value>
                                    <ScaleTransform ScaleX="2" ScaleY="2" />
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
