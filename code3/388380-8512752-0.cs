    <Border x:Name="layout"
            Grid.Row="1"
            Background="Transparent"
            BorderBrush="#BAC8CE"
            BorderThickness="1"
            CornerRadius="5">
      <Border.Style>
        <Style TargetType="{x:Type Border}">
          <Style.Triggers>
            <DataTrigger Binding="{Binding Side, ElementName=uc, Mode=OneWay}"
                          Value="Up">
              <DataTrigger.EnterActions>
                <BeginStoryboard>
                  <Storyboard>
                    <ColorAnimation Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)"
                                    Duration="00:00:05"
                                    From="Transparent"
                                    To="Green" />
                    <ColorAnimation Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)"
                                    Duration="00:00:00.5"
                                    From="Green"
                                    To="Transparent" />
                  </Storyboard>
                </BeginStoryboard>
              </DataTrigger.EnterActions>
              <DataTrigger.ExitActions>
                <BeginStoryboard>
                  <Storyboard>
                    <ColorAnimation Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)"
                                    Duration="00:00:05"
                                    From="Transparent"
                                    To="Red" />
                    <ColorAnimation Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)"
                                    Duration="00:00:00.5"
                                    From="Red"
                                    To="Transparent" />
                  </Storyboard>
                </BeginStoryboard>
              </DataTrigger.ExitActions>
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </Border.Style>
    </Border>
