    <Style.Triggers>
    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding ElementName=button1, Path=Content}" Value="Select" />
            <Condition Binding="{Binding ElementName=checkBox1, Path=IsChecked }" Value="True" />
        </MultiDataTrigger.Conditions>
        <Setter Property="SomeProperty" Value="SomeValue" />
    </MultiDataTrigger>
    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding ElementName=button1, Path=Content}" Value="Select" />
            <Condition Binding="{Binding ElementName=checkBox2, Path=IsChecked }" Value="True" />
        </MultiDataTrigger.Conditions>
        <Setter Property="SomeProperty" Value="SomeValue" />
    </MultiDataTrigger>
    </Style.Triggers>
