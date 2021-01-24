    <UserControl ...>
        <UserControl.Template>
            <ControlTemplate TargetType="UserControl">
                <ContentPresenter
                    HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"/>
            </ControlTemplate>
        </UserControl.Template>
        <Grid Background="AliceBlue">
            <TextBlock
                Text="Hello"
                VerticalAlignment="{Binding VerticalContentAlignment,
                    RelativeSource={RelativeSource AncestorType=UserControl}}"/>
        </Grid>
    </UserControl>
