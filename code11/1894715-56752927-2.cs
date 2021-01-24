      <DataGrid Name="drg" AutoGenerateColumns="False"  CanUserAddRows="False" >
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Date" >
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBox  BorderThickness="0" >
                                    <TextBox.Style>
                                        <Style TargetType="TextBox">
                                            <Style.Resources>
                                                <Converter:DateTimeNullConverter x:Key="Time"/>
                                            </Style.Resources>
                                            <Setter Property="Text" Value="{Binding Date}"></Setter>
                                            <Style.Triggers>
                                                <Trigger Property="TextBox.IsKeyboardFocused" Value="True">
                                                    <Setter Property="Text" Value="{Binding Date,Converter={StaticResource Time}}"></Setter>
                                                </Trigger>
                                            </Style.Triggers>
                                        </Style>
                                    </TextBox.Style>
                                    
                                </TextBox>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
