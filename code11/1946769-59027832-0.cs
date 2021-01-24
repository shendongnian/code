       <Grid Margin="10">
        <ListView Name="lvUsers" Margin="0,0,290,0">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Name" Width="120" DisplayMemberBinding="{Binding Name}" />
                    <GridViewColumn Header="Age" Width="50" DisplayMemberBinding="{Binding Age}" />
                </GridView>
            </ListView.View>
            <ListView.GroupStyle>
                <GroupStyle>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <Expander IsExpanded="True">
                                            <Expander.Style>
                                                <Style TargetType="{x:Type Expander}">
                                                    <Setter Property="Visibility" Value="Visible" />
                                                    <Setter Property="Template">
                                                        <Setter.Value>
                                                            <ControlTemplate TargetType="{x:Type Expander}">
                                                                <Border Background="{TemplateBinding Background}">
                                                                    <DockPanel>
                                                                        <ToggleButton x:Name="HeaderSite" MinWidth="0" MinHeight="0"   Content="{TemplateBinding Header}" 
                         ContentTemplate="{TemplateBinding HeaderTemplate}" 
                         ContentTemplateSelector="{TemplateBinding HeaderTemplateSelector}"  
                         DockPanel.Dock="Top" 
                         FocusVisualStyle="{DynamicResource ExpanderHeaderFocusVisual}"   
                         IsChecked="{Binding IsExpanded, Mode=TwoWay, RelativeSource={RelativeSource 
                          TemplatedParent}}" 
                         Style="{DynamicResource ExpanderDownHeaderStyle}" />
                                                                        <ContentPresenter x:Name="ExpandSite" DockPanel.Dock="Bottom" Focusable="false" 
                         Visibility="Collapsed" />
                                                                    </DockPanel>
                                                                </Border>
                                                                <ControlTemplate.Triggers>
                                                                    <Trigger Property="IsExpanded" Value="true">
                                                                        <Setter TargetName="ExpandSite" Property="Visibility" Value="Visible" />
                                                                    </Trigger>
                                                                    <Trigger Property="IsEnabled" Value="false">
                                                                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                                                                    </Trigger>
                                                                </ControlTemplate.Triggers>
                                                            </ControlTemplate>
                                                        </Setter.Value>
                                                    </Setter>
                                                </Style>
                                            </Expander.Style>
                                            <Expander.Header>
                                                <StackPanel Orientation="Horizontal">
                                                    <TextBlock Text="{Binding Name}" FontWeight="Bold" Foreground="Gray" FontSize="22" VerticalAlignment="Bottom" />
                                                    <TextBlock Text="{Binding ItemCount}" FontSize="22" Foreground="Green" FontWeight="Bold" FontStyle="Italic" Margin="10,0,0,0" VerticalAlignment="Bottom" />
                                                    <TextBlock Text=" item(s)" FontSize="22" Foreground="Silver" FontStyle="Italic" VerticalAlignment="Bottom" />
                                                </StackPanel>
                                            </Expander.Header>
                                            <ItemsPresenter />
                                        </Expander>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </GroupStyle.ContainerStyle>
                </GroupStyle>
            </ListView.GroupStyle>
        </ListView>
        <Button x:Name="button" Content="HideAllExpanders" HorizontalAlignment="Left" Margin="578,52,0,0" VerticalAlignment="Top" Width="154" Click="Button_Click"/>
        <Button x:Name="button1" Content="ShowAllExpanders" HorizontalAlignment="Left" Margin="578,128,0,0" VerticalAlignment="Top" Width="154" Click="Button1_Click"/>
    </Grid>
