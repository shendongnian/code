    <ComboBox ItemsSource="{Binding EndpointModel.DisplayFormat}" 
              VerticalAlignment="Center" Margin="0,0,10,0" 
              SelectedItem="{Binding EndpointModel.SelectMediaFormat}"
              DisplayMemberPath="Name">
         <ComboBox.ItemContainerStyle>
              <Style TargetType="ComboBoxItem">
                  <Setter Property="IsEnabled" Value="{Binding IsEnabled}" />
              </Style>
         </ComboBox.ItemContainerStyle>
    </ComboBox>
