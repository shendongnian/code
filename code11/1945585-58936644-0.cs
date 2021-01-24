    <CheckBox DataContext="{Binding DataContext, RelativeSource={RelativeSource AncestorType=UserControl}}">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="Checked">
                <i:InvokeCommandAction Command="{Binding CheckAllRowsCommand}"/>
            </i:EventTrigger>
            <i:EventTrigger EventName="Unchecked">
                <i:InvokeCommandAction Command="{Binding UncheckAllRowsCommand}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </CheckBox>
