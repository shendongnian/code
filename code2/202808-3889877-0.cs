    <Window.Resources>
        <ResourceDictionary>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="BorderThickness"
                        Value="3" />
                <Setter Property="BorderBrush"
                        Value="Blue" />
                <Setter Property="VerticalContentAlignment"
                        Value="Center" />
                <Setter Property="HorizontalContentAlignment"
                        Value="Center" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TabItem}">
                            <Border>
                                <Grid>
                                    <Grid>
                                        <Border x:Name="border" 
                                                CornerRadius="3,3,0,0"
                                                Background="{TemplateBinding Background}"
                                                BorderBrush="{TemplateBinding BorderBrush}"
                                                BorderThickness="1,1,1,0" />
                                    </Grid>
                                    <Border BorderThickness="{TemplateBinding BorderThickness}"
                                            Padding="{TemplateBinding Padding}">
                                        <ContentPresenter ContentSource="Header"
                                                          HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                                          VerticalAlignment="{TemplateBinding VerticalContentAlignment}" />
                                    </Border>
                                </Grid>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsSelected"
                                         Value="True">
                                    <Setter TargetName="border"
                                            Property="BorderBrush"
                                            Value="Red" />
                                    <Setter TargetName="border"
                                            Property="BorderThickness"
                                            Value="0,3,0,0" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ResourceDictionary>
    </Window.Resources>
    <Grid>
        <TabControl>
            <TabControl.Background>
                <LinearGradientBrush EndPoint="0,1"
                                     StartPoint="0,0">
                    <GradientStop Color="#FFCCCCD0" />
                    <GradientStop Color="#FF526593"
                                  Offset="1" />
                </LinearGradientBrush>
            </TabControl.Background>
            <TabItem Header="test1">
                <TabItem.Content>
                    <StackPanel Orientation="Horizontal">
                        <Button Content="Test"
                                VerticalAlignment="Center" />
                        <Button Content="Test2" />
                    </StackPanel>
                </TabItem.Content>
            </TabItem>
            <TabItem Header="Test2">
                <TabItem.Content>
                    <TextBox />
                </TabItem.Content>
            </TabItem>
        </TabControl>
    </Grid>
