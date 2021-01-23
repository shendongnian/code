    <GridViewColumn Width="Auto" Header="Value">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid HorizontalAlignment="Stretch" MinWidth="100">
                                    <jha:JHARegularTextBlock Text="{Binding FieldValue}" />
                                </Grid>
                                <DataTemplate.Triggers>
                                    <DataTrigger Binding="{Binding IsSelected}" Value="True">
                                        <Setter Property="local:FocusBehavior.IsFocused" TargetName="FieldValueEditor" Value="True" />
                                    </DataTrigger>
                                </DataTemplate.Triggers>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
