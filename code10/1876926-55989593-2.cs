    private void EventHandler()
    { 
      IsBusy.Visibility = Visibility.Visible;
      BusyIndicator.Header = "Imprimiendo...";
      var printDialog = new PrintDialog();
      if ((bool)printDialog.ShowDialog())
      {
          await Task.Run ( () => printDialog.PrintVisual(PrintCanvas, "Iprimiendo Venta " + _vm.Sell.Id) ) ;
      }    
      IsBusy.Visibility = Visibility.Hidden;
      BusyIndicator.Header = "Cargando...";
    }
