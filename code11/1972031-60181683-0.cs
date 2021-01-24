<DataGridTemplateColumn Header="Stalviršio tipas">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Grid>
                                <ComboBox x:Name="TableTop" DropDownClosed="TableTop_DropDownClosed" ItemsSource="{Binding}">
                                    <ComboBoxItem Content="" />
                                    <ComboBoxItem Content="A" />
                                    <ComboBoxItem Content="B" />
                                    <ComboBoxItem Content="C" />
                                </ComboBox>
                                <TextBlock Text="{Binding tabletop_letter}" IsHitTestVisible="False">
                                    <TextBlock.Style>
                                        <Style TargetType="TextBlock">
                                            <Setter Property="Visibility" Value="Hidden"/>
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding ElementName=TableTop,Path=SelectedItem}" Value="{x:Null}">
                                                    <Setter Property="Visibility" Value="Visible"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </TextBlock.Style>
                                </TextBlock>
                            </Grid>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
