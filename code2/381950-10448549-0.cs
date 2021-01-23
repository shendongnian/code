         <ComboBox Name="TestCombo" ItemsSource="{Binding Path=DataSource.DefaultValues}" DisplayMemberPath="Name" SelectedValuePath="IsSelected" SelectionChanged="Test_SelectionChanged">
                    <ComboBox.Resources>                    
                        <Style TargetType="{x:Type ComboBoxItem}">
                            <Style.Triggers>
                                <Trigger Property="IsSelected" Value="True">
                                    <Setter Property="StackOverflow:IsSelectedBehavior.IsSelected" Value="True"></Setter>
                                </Trigger>
                                <Trigger Property="IsSelected" Value="False">
                                    <Setter Property="StackOverflow:IsSelectedBehavior.IsSelected" Value="False"></Setter>
                                </Trigger>
                            </Style.Triggers>
                        </Style>
                    </ComboBox.Resources>
                </ComboBox>
