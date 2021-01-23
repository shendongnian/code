    <TextBox IsEnabled="{Binding ElementName=ProxyModeRadioButton, UpdateSourceTrigger=PropertyChanged, Path=IsChecked}" Width="Auto" Name="ProxyHostTextBox" VerticalAlignment="Center" MinWidth="150" >
        <TextBox.Text>
            <Binding Path="Proxy" >
                <Binding.ValidationRules>
                    <local:SpecialCharactersRule/> 
                </Binding.ValidationRules>
            </Binding>
        </TextBox.Text>
    </TextBox>
