    <Grid>
      <Grid.Resources>
        <System:Double x:Key="boundDouble">1000</System:Double>
        <System:Double x:Key="boundDouble2">2000</System:Double>
      </Grid.Resources>
      <TextBox Width="100" Height="30">
        <TextBox.Text>
          <Binding Source="{StaticResource boundDouble}" Path="." StringFormat="{}{0:F3}" />
        </TextBox.Text>
        <TextBox.Style>
          <Style TargetType="TextBox">
            <Style.Triggers>
              <Trigger Property="IsFocused" Value="true">
                <Setter Property="Template">
                  <Setter.Value>
                    <ControlTemplate TargetType="TextBox">
                      <TextBox>
                      <TextBox.Text>
                        <Binding Source="{StaticResource boundDouble}" Path="." StringFormat="{}{0:F5}" />
                      </TextBox.Text>
                      </TextBox>
                    </ControlTemplate>
                  </Setter.Value>
                </Setter>
              </Trigger>
            </Style.Triggers>
          </Style>
        </TextBox.Style>
      </TextBox>
    </Grid>
