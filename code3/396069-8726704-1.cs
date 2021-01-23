    using System;
    using System.Collections.Generic;
    using System.Text;
    
    
    namespace Tools.Serialization.CSV
    {
    
        //------------------------
        //   RECORD CLASS (Example, change at your will)
        //   TIP: Remember to use the wizard to generate this class
        public class Customer
        {
            public int CustId;
    
            public string Name;
            public decimal Balance;
            [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Date, "ddMMyyyy")]
            public DateTime AddedDate;
        }
    
    
    }
