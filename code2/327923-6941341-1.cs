    public class BusinessLayerHandler
    {
        public static DataTable unitTable;
        public static DataTable currencyTable;
        private static readonly object unitTableLock = new object();
        private static readonly object currencyTableLock = new object();
        public static DataTable GetUnitList()
        {
            //import lists each time the application is run
            lock(unitTableLock)
            {
                if (unitTable == null)
                {
                    unitTable = DatabaseHandler.GetUnitList();
                }
            }
            
            return unitTable;
        }
        public static DataTable GetCurrencyList()
        {
            //import lists each time the application is run
            lock(currencyTableLock)
            {
                if (currencyTable == null)
                {
                    currencyTable = DatabaseHandler.GetCurrencyList();
                }
            }
            return currencyTable;
        }
    }
