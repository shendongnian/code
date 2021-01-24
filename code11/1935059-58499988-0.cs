    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(Data.User.userType.ClientUser,
                                              Data.Enitity.entityname);
            }
        }  
    }
