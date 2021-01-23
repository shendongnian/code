    public interface IDataAccess
    {
       DbValue GetFromDb(int accountId);  
    }
    var dataAccessMock = Mock.Of<IDataAccess>
    (da => da.GetFromDb(It.Is<int>(acctId => acctId == 0)) == new Account { AccountStatus = AccountStatus.None }
    && da.GetFromDb(It.Is<int>(acctId => acctId == 1)) == new DbValue { AccountStatus = AccountStatus.InActive }
    && da.GetFromDb(It.Is<int>(acctId => acctId == 2)) == new DbValue { AccountStatus = AccountStatus.Deleted });
    var result1 = dataAccessMock.GetFromDb(0); // returns DbValue of "None" AccountStatus
    var result2 = dataAccessMock.GetFromDb(1); // returns DbValue of "InActive"   AccountStatus
    var result3 = dataAccessMock.GetFromDb(2); // returns DbValue of "Deleted" AccountStatus
