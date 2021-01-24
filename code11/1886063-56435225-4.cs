    public ActionResult Add(Models.ViewModels.Loans.LoanEditorViewModel loanEditorViewModel)
    {
        if (!ModelState.IsValid)
            return View(loanEditorViewModel);
    
        var loanViewModel = loanEditorViewModel.LoanViewModel;
        using (var contextScope = ContextScopeFactory.Create())
        {
           var loanProduct = LoanRepository.GetLoanProductById( loanViewModel.LoanProductId).Single();
           var borrower = LoanRepository.GetBorrowerById(loanViewModel.BorrowerId);
           var loan = LoanRepository.CreateLoan(loanViewModel, loanProduct, borrower).Single();
           contextScope.SaveChanges();
        }
        return RedirectToAction("Index");
    }
