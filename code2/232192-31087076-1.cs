    async private void Add_Click(object sender, RoutedEventArgs e)
        {
            List<IceCream> items = new List<IceCream>();
            foreach (IceCream item in IceCreamList.SelectedItems)
            {
                int i=Flavors.IndexOf(item);
                Flavors[i].Liczba =item.Liczba+ 1;
                //Flavors.Remove(item);
                
                //item.Liczba += 1;
                
               // items.Add(item);
               // Flavors.Add(item);
            }
            MessageDialog d = new MessageDialog("Zwiększono liczbę o jeden");
            d.Content = "Zwiększono liczbę o jeden";
            await d.ShowAsync();
            
            IceCreamList.SelectedIndex = -1;
        }
    }
