    <Page xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
      <Grid>
        <Grid.ColumnDefinitions>
          <ColumnDefinition/>
          <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Border Background="Green" Grid.Column="0" x:Name="green">
          <Border.Style>
            <Style TargetType="Border">
              <Style.Triggers>
                <!-- switch off when the button is pressed -->
                <DataTrigger Binding="{Binding IsChecked, ElementName=greenB}"
                             Value="True">
                  <Setter Property="Visibility" Value="Hidden"/>
                </DataTrigger>
              </Style.Triggers>
            </Style>
          </Border.Style>
          <!-- we use radiobuttons, because they are mutually exclusive without
               code-behind -->
          <RadioButton Width="150" Height="25"
                       HorizontalAlignment="Right" VerticalAlignment="Bottom"
                       Margin="15" x:Name="greenB" Content="Hide" GroupName="x">
            <RadioButton.Style>
              <Style TargetType="RadioButton">
                <Style.Triggers>
                  <DataTrigger Binding="{Binding IsChecked, ElementName=redB}"
                               Value="True">
                    <Setter Property="IsChecked" Value="False"/>
                  </DataTrigger>
                </Style.Triggers>
              </Style>
            </RadioButton.Style>
            <RadioButton.Template>
              <ControlTemplate>
                <ToggleButton IsChecked="{Binding IsChecked, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"
                              Content="{Binding Content, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"/>
              </ControlTemplate>
            </RadioButton.Template>
          </RadioButton>
        </Border>
        <Border Background="Red" Grid.Column="1" x:Name="red">
          <Border.Style>
            <Style TargetType="Border">
              <Style.Triggers>
                <DataTrigger Binding="{Binding IsChecked, ElementName=redB}" Value="True">
                  <Setter Property="Visibility" Value="Hidden"/>
                </DataTrigger>
              </Style.Triggers>
            </Style>
          </Border.Style>
          <RadioButton Width="150" Height="25"
                       HorizontalAlignment="Right" VerticalAlignment="Bottom"
                       Margin="15" x:Name="redB" Content="Hide" GroupName="x">
            <RadioButton.Style>
              <Style TargetType="RadioButton">
                <Style.Triggers>
                  <DataTrigger Binding="{Binding IsChecked, ElementName=greenB}" Value="True">
                    <Setter Property="IsChecked" Value="False"/>
                  </DataTrigger>
                </Style.Triggers>
              </Style>
            </RadioButton.Style>
            <RadioButton.Template>
              <ControlTemplate>
                <ToggleButton IsChecked="{Binding IsChecked, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"
                              Content="{Binding Content, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"/>
              </ControlTemplate>
            </RadioButton.Template>
          </RadioButton>
        </Border>
      </Grid>
    </Page>
