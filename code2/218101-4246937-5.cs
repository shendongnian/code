    <ListView ...>
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Style.Resources>
                    <LinearGradientBrush x:Key="ListItemHoverFill" EndPoint="0,1" StartPoint="0,0">
                        <GradientStop Color="#FFF1FBFF" Offset="0"/>
                        <GradientStop Color="#FFD5F1FE" Offset="1"/>
                    </LinearGradientBrush>
                </Style.Resources>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListViewItem}">
                            <Border CornerRadius="2" SnapsToDevicePixels="True"  
                                    BorderThickness="{TemplateBinding BorderThickness}"   
                                    BorderBrush="{TemplateBinding BorderBrush}"   
                                    Background="{TemplateBinding Background}">
                                <Border Name="InnerBorder" CornerRadius="1" BorderThickness="1">
                                    <Grid>
                                        <Grid.RowDefinitions>
                                            <RowDefinition MaxHeight="11" />
                                            <RowDefinition />
                                        </Grid.RowDefinitions>
                                        <Rectangle Name="UpperHighlight" Visibility="Collapsed" Fill="#75FFFFFF" />
                                        <GridViewRowPresenter Grid.RowSpan="2"   
                                                VerticalAlignment="{TemplateBinding VerticalContentAlignment}"   
                                                SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                                    </Grid>
                                </Border>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter Property="Background" Value="{StaticResource ListItemHoverFill}" />
                                    <Setter Property="BorderBrush" Value="#FFCCF0FF" />
                                    <Setter TargetName="UpperHighlight" Property="Visibility" Value="Visible" />
                                </Trigger>
                                <!--<Trigger Property="IsSelected" Value="True">
                                    <Setter Property="Background" Value="{StaticResource ListItemSelectedFill}" />
                                    <Setter Property="BorderBrush" Value="#FF98DDFB" />
                                    <Setter TargetName="InnerBorder" Property="BorderBrush" Value="#80FFFFFF" />
                                    <Setter TargetName="UpperHighlight" Property="Visibility" Value="Visible" />
                                    <Setter TargetName="UpperHighlight" Property="Fill" Value="#40FFFFFF" />
                                </Trigger>-->
                                <!--<MultiTrigger> 
                    <MultiTrigger.Conditions> 
                        <Condition Property="IsSelected" Value="True" /> 
                        <Condition Property="Selector.IsSelectionActive" Value="False" /> 
                    </MultiTrigger.Conditions> 
                    <Setter Property="Background" Value="{StaticResource ListItemSelectedInactiveFill}" /> 
                    <Setter Property="BorderBrush" Value="#FFCFCFCF" /> 
                </MultiTrigger>-->
                                <!--<MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="IsSelected" Value="True" />
                                        <Condition Property="IsMouseOver" Value="True" />
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" Value="{StaticResource ListItemSelectedHoverFill}" />
                                    <Setter Property="BorderBrush" Value="#FF98DDFB" />
                                </MultiTrigger>-->
                                <Trigger Property="IsEnabled" Value="False">
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.ItemContainerStyle>
    </ListView>
