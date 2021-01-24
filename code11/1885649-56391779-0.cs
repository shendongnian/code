<ToggleButton
               Name="ToggleButton_Record"
               IsChecked="False"
               ToolTip="Записать">
              <ToggleButton.Style>
                   <Style TargetType="{x:Type ToggleButton}" BasedOn="{StaticResource MaterialDesignActionToggleButton}">
                       <Style.Triggers>
                            <Trigger Property="ToggleButton.IsChecked" Value="True">
                                 <Setter Property="Command" Value="{Binding StartRecordCommand}" />
                            </Trigger>
                            <Trigger Property="ToggleButton.IsChecked" Value="False">
                                  <Setter Property="Command" Value="{Binding StopRecordCommand}" />
                            </Trigger>
                        </Style.Triggers>
                   </Style>
              </ToggleButton.Style>
               <materialDesign:PackIcon
                    HorizontalAlignment="Center"
                    VerticalAlignment="Center"
                    Foreground="OrangeRed"
                    Kind="Record" />
</ToggleButton>
