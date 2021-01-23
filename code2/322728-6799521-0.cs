     <Button.Visibility>
        <Binding ElementName="checkBox" Path=IsChecked>
            <Binding.Converter>
                <BooleanToVisibilityConverter />
            </Binding.Converter>
        </Binding>
     </Button.Visibility>
