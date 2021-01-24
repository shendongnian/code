    private void TextboxBarCodeTextchanged(object sender,RoutedEventArgs e)
    {
 
    oldCollection = ObservableCollection;
    for (int i = 0; i < AllStockList.Count; i++)
       {
          if (!string.IsNullOrEmpty((sender as TextBox).Text))
          {
              if (AllStockList[i].BarCode.StartsWith((sender as TextBox).Text, 
              StringComparison.InvariantCultureIgnoreCase))
              {
                 var stock = AllStockList[i] as Stock;
                 ObservableCollection.Add(stock);
               }
             }
          }
                 DataGridSalesDetails.Visibility = Visibility.Visible;
                 TotalReturnAmount = filteredCollection.Sum(a => a.TotalAmount);
                 HiddenTotalAount.Text = TotalReturnAmount.ToString();
                 LabelFinalAmountValue.Content = TotalReturnAmount.ToString();
    }
