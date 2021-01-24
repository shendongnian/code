    partial class DetailsPage {
        public ObservableCollection<EntityDetail> EntityDetails {get;}
        public DetailsPage( ObservableCollection<EntityDetail> entityDetails) {
            this.EntityDetails = entityDetails;
        } 
    }
    <Page
        x:Class="DetailsPage"
        …
        >
        <Page.Resources>
            <ResourceDictionary>
                <DataTemplate x:Name="EntityDetailDataTemplate" x:DataType="local:EntityDetail">
                    <TextBlock Text={x:Bind Name, Mode=OneWay}/> (assuming Name is a property in EntityDetail)
                </DataTemplate>
            </ResourceDictionary>
        </Page.Resources>
        <ListView
            ItemsSource={x:Bind EntityDetails, Mode=OneWay}
            ItemTemplate={StaticResource EntityDetailDataTemplate}
            …
            >
        </ListView>
    </Page>
