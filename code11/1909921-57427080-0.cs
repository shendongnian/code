    <DatePicker Grid.Row="19" Grid.Column="1" Width="120"
                Visibility="{Binding IsChecked, ElementName=HireDeclinedYes, Converter={StaticResource BooleanToVisibilityConverter}}" >
        <DatePicker.Style>
            <Style TargetType="DatePicker">
                <Setter Property="SelectedDate" Value="{Binding SelectedApplication.DateHireDeclineSent}" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ElementName=HireDeclinedYes, Path=IsChecked, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Value="True">
                        <Setter Property="SelectedDate" Value="{x:Static sys:DateTime.Now}"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding ElementName=HireDeclinedYes, Path=IsChecked}" Value="False">
                        <Setter Property="SelectedDate" Value="{x:Null}"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DatePicker.Style>
    </DatePicker>
