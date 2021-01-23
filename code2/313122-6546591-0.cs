    <ContentControl>
        <ContentControl.Style>
            <Style TargetType="{x:Type ContentControl}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ViewMode}" Value="TreeMode">
                        <Setter Property="Content">
                            <Setter.Value>
                                <uc:TreeModeView />
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding ViewMode}" Value="GridMode">
                        <Setter Property="Content">
                            <Setter.Value>
                                <uc:GridModeView />
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
