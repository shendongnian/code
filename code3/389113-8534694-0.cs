            <StackPanel>
                <Button IsEnabled="{Binding ElementName=isEnabledCheckBox, Path=IsChecked}">
                    <TextBlock Text="Answer" TextWrapping="Wrap">
                        <TextBlock.Style>
                            <Style TargetType="{x:Type TextBlock}">
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Button}}, Path=IsEnabled}" Value="True">
                                        <Setter Property="Foreground" Value="Green"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </TextBlock.Style>
                    </TextBlock>
                </Button>
                <Button IsEnabled="{Binding ElementName=isEnabledCheckBox, Path=IsChecked}">
                    <TextBlock Text="Answer" TextWrapping="Wrap">
                        <TextBlock.Style>
                            <Style TargetType="{x:Type TextBlock}">
                                <Style.Triggers>
                                    <Trigger Property="IsEnabled" Value="True">
                                        <Setter Property="Foreground" Value="Green"/>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </TextBlock.Style>
                    </TextBlock>
                </Button>
                <CheckBox x:Name="isEnabledCheckBox" Content="Toggle IsEnable on Buttons above" />
                
            </StackPanel>
