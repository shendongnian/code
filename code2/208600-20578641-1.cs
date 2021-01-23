    <ComboBox>
       <ComboBox.ItemsSource>
          <CompositeCollection>
             <ComboBoxItem>Add New Item...</ComboBoxItem>
             <CollectionContainer Collection="{Binding Source={StaticResource CollectionSource}}"/>
          </CompositeCollection>
       </ComboBox.ItemsSource>
    </ComboBox>
