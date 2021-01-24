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
                                                <MultiDataTrigger>
                                                    <MultiDataTrigger.Conditions>
                                                        <Condition Binding="{Binding Date}" Value="{x:Null}" />
                                                        <Condition Binding="{Binding RelativeSource={RelativeSource Mode=Self}, Path=IsKeyboardFocused}" Value="True" />
                                                    </MultiDataTrigger.Conditions>
                                                    <Setter Property="Text" Value="{Binding Date,Converter={StaticResource Time}}"></Setter>
                                                </MultiDataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </TextBox.Style>
                                </TextBox>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
