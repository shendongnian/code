    <Style TargetType="TextBlock">
      <Setter Property="Visibility" Value="Collapsed" />
      <Style.Triggers>
        <MultiDataTrigger>
          <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding Binding1}" Value="Condition1" />
            <Condition Binding="{Binding Binding2}" Value="Condition2" />
          </MultiDataTrigger.Conditions>
          <Setter Property="Visibility" Value="Visible" />
        </MultiDataTrigger>
      </Style.Triggers>
    </Style>
