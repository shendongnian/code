    <ComboBox>
       <ComboBox.ItemsSource>
          <CompositeCollection>
             <ComboBoxItem>Add New Item...</ComboBoxItem>
             <CollectionContainer Collection="{Binding MyCollection}"/>
          </CompositeCollection>
       </ComboBox.ItemsSource>
    </ComboBox>
