    <StackPanel Orientation="Horizontal">
         <TextBlock Text="{Binding Title}" />
         <TextBox Text="{Binding Text}">
              <TextBox.Style>
                  <Style TargetType="TextBox">
                      <Setter Property="Visibility" Value="Collapsed" />
                      <Style.Triggers>
                          <DataTrigger Binding="{Binding BoxMode}" Value="Box">
                              <Setter Property="Visibility" Value="Visible" />
                          </DataTrigger>
                      </Style.Triggers>
                  </Style>
              </TextBox.Style>
         </TextBox>
         <TextBlock Text="{Binding Text}">
              <TextBlock.Style>
                  <Style TargetType="TextBlock">
                      <Setter Property="Visibility" Value="Visible" />
                      <Style.Triggers>
                          <DataTrigger Binding="{Binding BoxMode}" Value="Box">
                              <Setter Property="Visibility" Value="Collapsed" />
                          </DataTrigger>
                      </Style.Triggers>
                  </Style>
              </TextBlock.Style>
         </TextBlock>
    </StackPanel>
