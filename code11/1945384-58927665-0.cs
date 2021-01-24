    var v = new SendCheckBillViewModel(); 
     v.StatusViewModel = new StatusViewModel();
     v.GetCheckBillViewModel = new List<GetCheckBillViewModel>();
     
     v.StatusViewModel.StatusCode = 200;
     v.StatusViewModel.Message = "";
     v.GetCheckBillViewModel.AddRange(viewList);
