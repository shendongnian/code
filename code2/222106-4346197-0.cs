     <x:Code>
                <![CDATA[
    
                void ButtonOnClick(object sender, RoutedEventArgs args)
                {
                    Button btn = sender as Button;
                    MessageBox.Show("The button labeled '" +
                                    btn.Content +
                                    "' has been clicked.","Information Message");
                }
                ]]>
      </x:Code>
