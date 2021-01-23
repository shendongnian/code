    <ToggleButton x:Name="tgBtn" Height="20" Width="20" IsChecked="{Binding IsVisible}" 
                  BorderThickness="0" Background="Transparent" >
        <ToggleButton.Style>
            <Style TargetType="{x:Type ToggleButton}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate>
                            <Image Width="18"
                               Height="18"                 
                               Source="C:\USERS\thumbnail.jpeg">
                                <Image.Style>
                                    <Style TargetType="{x:Type Image}">
                                        <Setter Property="Opacity" Value="1"/>
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding ElementName=tgBtn, Path=IsChecked}" Value="false">
                                                <Setter Property="Opacity" Value="0.5"/>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </Image.Style>
                            </Image>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ToggleButton.Style>
    </ToggleButton>
