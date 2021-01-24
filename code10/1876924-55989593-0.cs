    private async Task DoPrint()
    {
      IsBusy.Visibility = Visibility.Visible;
      BusyIndicator.Header = "Imprimiendo...";
      var printDialog = new PrintDialog();
      if ((bool)printDialog.ShowDialog())
          printDialog.PrintVisual(PrintCanvas, "Iprimiendo Venta " + _vm.Sell.Id);
      IsBusy.Visibility = Visibility.Hidden;
      BusyIndicator.Header = "Cargando...";
    }
    private void EventHandler()
    { 
      await DoPrint() ;
    }
