    Example (untested):
        <SomeElementOutsideYourDataGrid Tag="{Binding TheModel}" />
        ...
            <Button>
                <Button.Visibility>
                    <MultiBinding Converter="{StaticResource yourMultiValueConverter}">
                        <Binding Path="IsEditable" />
                        <Binding ElementName="SomeElementOutsideYourDataGrid" Path="Tag.IsAdmin"/>
                    </MultiBinding>
                </Button.Visibility>
            </Button>
