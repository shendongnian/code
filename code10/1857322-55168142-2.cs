             <Border BorderBrush="Gray" Background="LightGray" BorderThickness="2" MaxWidth="142" HorizontalAlignment="Left">
                <StackPanel HorizontalAlignment="Left">                    
                    <Grid Margin="2">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="auto"/>
                            <ColumnDefinition Width="*"/>
                        </Grid.ColumnDefinitions>
                        <TextBlock>Channel</TextBlock>
                        <TextBox Grid.Column="1" Margin="5,0,0,0">AMMC_TX1</TextBox>
                    </Grid>
                        <ScrollViewer VerticalScrollBarVisibility="Disabled" HorizontalScrollBarVisibility="Visible">
                    <UniformGrid HorizontalAlignment="Left" Rows="1">
                            <!--Turn me into a custom control-->
                            <Border BorderBrush="Gray" BorderThickness="2" MaxWidth="50">
                                <StackPanel>
                                    <TextBlock>Label</TextBlock>
                                    <TextBox>1</TextBox>
                                    <CheckBox IsChecked="True" Margin="5">
                                        <CheckBox.Style>
                                            <Style TargetType="CheckBox">
                                                <Setter Property="Template">
                                                    <Setter.Value>
                                                        <ControlTemplate TargetType="CheckBox">
                                                            <Grid>
                                                                <Ellipse Name="eli" Height="30" Width="30" Fill="DarkGreen"/>
                                                            </Grid>
                                                            <ControlTemplate.Triggers>
                                                                <Trigger Property="IsChecked" Value="True">
                                                                    <Setter TargetName="eli" Property="Fill" Value="Lime"/>
                                                                </Trigger>
                                                            </ControlTemplate.Triggers>
                                                        </ControlTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </Style>
                                        </CheckBox.Style>
                                    </CheckBox>
                                    <TextBlock>Content</TextBlock>
                                    <TextBox>11</TextBox>
                                    <TextBox>22</TextBox>
                                    <TextBox>33</TextBox>
                                </StackPanel>
                            </Border>
                            <!--Turn me into a custom control-->
                            <Border BorderBrush="Gray" BorderThickness="2" MaxWidth="50">
                                <StackPanel>
                                    <TextBlock>Label</TextBlock>
                                    <TextBox>1</TextBox>
                                    <CheckBox IsChecked="True" Margin="5">
                                        <CheckBox.Style>
                                            <Style TargetType="CheckBox">
                                                <Setter Property="Template">
                                                    <Setter.Value>
                                                        <ControlTemplate TargetType="CheckBox">
                                                            <Grid>
                                                                <Ellipse Name="eli" Height="30" Width="30" Fill="DarkGreen"/>
                                                            </Grid>
                                                            <ControlTemplate.Triggers>
                                                                <Trigger Property="IsChecked" Value="True">
                                                                    <Setter TargetName="eli" Property="Fill" Value="Lime"/>
                                                                </Trigger>
                                                            </ControlTemplate.Triggers>
                                                        </ControlTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </Style>
                                        </CheckBox.Style>
                                    </CheckBox>
                                    <TextBlock>Content</TextBlock>
                                    <TextBox>11</TextBox>
                                    <TextBox>22</TextBox>
                                    <TextBox>33</TextBox>
                                </StackPanel>
                            </Border>
                            <!--Turn me into a custom control-->
                            <Border BorderBrush="Gray" BorderThickness="2" MaxWidth="50">
                                <StackPanel>
                                    <TextBlock>Label</TextBlock>
                                    <TextBox>1</TextBox>
                                    <CheckBox IsChecked="True" Margin="5">
                                        <CheckBox.Style>
                                            <Style TargetType="CheckBox">
                                                <Setter Property="Template">
                                                    <Setter.Value>
                                                        <ControlTemplate TargetType="CheckBox">
                                                            <Grid>
                                                                <Ellipse Name="eli" Height="30" Width="30" Fill="DarkGreen"/>
                                                            </Grid>
                                                            <ControlTemplate.Triggers>
                                                                <Trigger Property="IsChecked" Value="True">
                                                                    <Setter TargetName="eli" Property="Fill" Value="Lime"/>
                                                                </Trigger>
                                                            </ControlTemplate.Triggers>
                                                        </ControlTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </Style>
                                        </CheckBox.Style>
                                    </CheckBox>
                                    <TextBlock>Content</TextBlock>
                                    <TextBox>11</TextBox>
                                    <TextBox>22</TextBox>
                                    <TextBox>33</TextBox>
                                </StackPanel>
                            </Border>
                        </UniformGrid>
                        </ScrollViewer>
                </StackPanel>
                </Border>
