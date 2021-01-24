    public class Contract {
        
        public void AddAdditionalClause(BankEmployee employee, Clause clause) {
            AddEvent(new AdditionalClauseAdded(employee, clause));
        }
    }
