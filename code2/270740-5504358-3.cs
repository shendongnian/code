    public int GetNewSalary(IDBRepository aRepository,int aRaiseAmount){
        //This call can now be mocked to always return something.
        int oldSalary = aRepository.GetSalary();
        return oldSalary + aRaiseAmount;
    }
