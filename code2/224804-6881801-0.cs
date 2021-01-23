    <chartingToolkit:Chart.Axes>
                            <chartingToolkit:DateTimeAxis x:Name="LevelsDateTimeAxis" Orientation="X" Minimum="{Binding ElementName=PatientWindow, Path=MinimumTime}" Maximum="{Binding ElementName=PatientWindow, Path=MaximumTime}">
                                <chartingToolkit:DateTimeAxis.Style>
                                    <Style TargetType="{x:Type chartingToolkit:DateTimeAxis}">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding ElementName=WeekCheckbox, Path=IsChecked}"
                                                         Value="True">
                                                <Setter Property="IntervalType"
                                                        Value="Days" />
                                                <!-- You might need to adjust the Interval to 1 Here -->
                                            </DataTrigger>
                                            <!-- Continue With the Next Checkbox -->
                                        </Style.Triggers>
                                    </Style>
                                </chartingToolkit:DateTimeAxis.Style>
                            </chartingToolkit:DateTimeAxis>
