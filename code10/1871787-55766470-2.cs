         <ComboBox Name="Cmb1" ItemsSource="{Binding Cmb1List}" SelectedItem="{Binding Cmb1SelectedItem}">
                    
                </ComboBox>
        
                <ComboBox Name="Cmb2"  >
                    <ComboBox.Style>
                        <Style TargetType="{x:Type ComboBox}">
     <Setter Property="ItemsSource" Value="{Binding ObservableCollectionC}"></Setter>
                            <Style.Triggers>
        <DataTrigger Binding="{Binding Cmb1SelectedItem}" Value="A">
                                    <Setter Property="ItemsSource" Value="{Binding ObservableCollectionA}"></Setter>
                                </DataTrigger>
                                <DataTrigger Binding="{Binding Cmb1SelectedItem}" Value="B">
                                    <Setter Property="ItemsSource" Value="{Binding ObservableCollectionB}"></Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ComboBox.Style>
                </ComboBox>
