            <ComboBox Name="cb">
                <ComboBoxItem>Yes</ComboBoxItem>
                <ComboBoxItem>No</ComboBoxItem>
            </ComboBox>
            <TextBox>
                <TextBox.Style>
                    <Style TargetType="TextBox">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding ElementName=cb, Path=SelectedItem.Content}" Value="Yes">
                                <Setter Property="Text" Value="cleared"/>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding ElementName=cb, Path=SelectedItem.Content}" Value="No">
                                <Setter Property="Text" Value="not cleared"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </TextBox.Style>
            </TextBox>
