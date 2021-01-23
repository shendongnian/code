      if (dgCoil.ItemsSource.Cast<BLL.Coil>().ToList().Count != dgCoil.ItemsSource.Cast<BLL.Coil>().Select(c => c.CoilNo).Distinct().Count())
      {    
        //Duplicate detected !!
        return;
      }
