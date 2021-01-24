    <DataGridTextColumn x:Name="Teur_ProjectColumn" Binding="{Binding Teur_Project}">
        <DataGridTextColumn.Header>
            <TextBlock Text="{Binding DataContext.PreTestInformationProjectAccessNames.PreTestInformationProjectAccessHighText,
                                RelativeSource={RelativeSource AncestorType=Window}}"/>
        </DataGridTextColumn.Header>
    </DataGridTextColumn>
