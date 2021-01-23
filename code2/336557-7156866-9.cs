    <ListView Name="lstTest">
                    <ListView.View>
                        <GridView>
                            <GridViewColumn Header="" Width="100">
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBox x:Uid="txtagevals" x:Name="txtAge" Height="25" Width="80" BorderThickness="1" BorderBrush="Black" Text="{Binding Path=Age}">
                                            <TextBox.Style>
                                                <Style TargetType="{x:Type TextBox}">
                                                    <Setter Property="Background" Value="Red"/>
                                                </Style>
                                            </TextBox.Style>
                                            <TextBox.Template>
                                                <ControlTemplate x:Uid ="txtagevals" TargetType="{x:Type TextBox}">
                                                    <Border Background="{TemplateBinding Background}"  
                        BorderBrush="Black" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="5">
                                                        <ScrollViewer x:Name="PART_ContentHost"/>
                                                    </Border>
                                                    <ControlTemplate.Triggers>
                                                        <Trigger Property="Text" Value="18">
                                                            <Setter Property="Background" Value="Green"/>
                                                        </Trigger>
                                                        <Trigger Property="Text" Value="">
                                                            <Setter Property="Background" Value="White"/>
                                                        </Trigger>
                                                    </ControlTemplate.Triggers>
                                                </ControlTemplate>
                                            </TextBox.Template>
                                        </TextBox>
                                    </DataTemplate>
    
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                        </GridView>
                    </ListView.View>
                </ListView>
