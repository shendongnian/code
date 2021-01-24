    public ActionResult Add(Models.ViewModels.Loans.LoanEditorViewModel loanEditorViewModel)
    {
        if (!ModelState.IsValid)
            return View(loanEditorViewModel);
    
        var loanViewModel = loanEditorViewModel.LoanViewModel;
        using (var context = new AppContext())
        {
           var loanProduct = context.LoanProducts.Single(x => x.LoanProductId == 
    loanViewModel.LoanProductId);
           var borrower = context.Borrowers.Single(x => x.BorrowerId == loanViewModel.BorrowerId);
           var loan = AutoMapper.Mapper.Map<Loan>(loanEditorViewModel.LoanViewModel);
           loan.LoanProduct = loanProduct;
           loan.Borrower = borrower;
           context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
