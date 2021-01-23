    <Style x:Key="editButton" TargetType="{x:Type Button}">
                <Setter Property="Background" Value="Transparent" />                          
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type Button}">
                            <Border Background="{TemplateBinding Background}">
                                <ContentPresenter HorizontalAlignment="Left" VerticalAlignment="Center" >
                                    <ContentPresenter.Resources>
                                        <Style TargetType="TextBlock">
                                            <Setter Property="TextTrimming" Value="CharacterEllipsis"></Setter>
                                        </Style>
                                    </ContentPresenter.Resources>
                                </ContentPresenter>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Background" Value="Transparent"/>                      
                    </Trigger>
                </Style.Triggers>
            </Style>
