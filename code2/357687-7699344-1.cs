    public class Bank
    {
        private Bank(string bankCode, string bankName)
        {
        }
        public static Bank Create(string bankCode, string bankName)
        {
            if (ConditionNotMet) return null; //or throw Exception
            return new Bank(string bankCode, string bankName);
        }
    }
