        <ListBox.ItemTemplate>
            <DataTemplate>
                <Button Content="^" IsEnabled="{Binding Path=IsNotFirst, Mode=OneWay}" 
                 Click="btnMoveFDAup"/>
            </DataTemplate>
        </ListBox.ItemTemplate>
        private void btnMoveFDAup(object sender, RoutedEventArgs e)
        {
            Button btn = ((Button)sender);
            // btn.DataContext will get you to the row object where you can retrieve the ID
        }
