    public void UploadWorkbook(Workbook workbook, string uploadedBy, string comments)
    {
        workbook.UploadedBy = uploadedBy;
        workbook.Comments = comments;
        using (var transaction = new TransactionScope())
        {
            var existing = _repository.Get(x => x.FileName == workbook.FileName);
            if (existing == null)
                _repository.Insert(workbook); // this works on the commit
            else
                _repository.Update(workbook); // this causes commit to fail
    
            _unitOfWork.Commit(); // fails when repository runs update method
            transaction.Complete();
        }
    }
