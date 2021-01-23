    <Style  TargetType="{x:Type v:ModalView}">
        <Setter Property="SnapsToDevicePixels"
                Value="True" />
        <Setter Property="Focusable"
                Value="False" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type v:ModalView}">
                    <Grid>
                        <Grid>
                            <ContentPresenter Name="PART_PrimaryContent"
                                              Content="{TemplateBinding Content}"/>
                        </Grid>
                        <Grid Name="PART_ModalContent">
                            <Border Background="DarkGray"
                                    Opacity="0.7" />
                            <ContentPresenter Content="{TemplateBinding ModalContent}" />
                        </Grid>
                            
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
