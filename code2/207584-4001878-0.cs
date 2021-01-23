    <Button.IsEnabled>
        <MultiBinding Converter="{StaticResource MyConverter}">
            <Binding Property1 />
            <Binding Property2 />
        </MultiBinding>
    </Button.IsEnabled>
