      public class RunData
      {
            #region Fields.
            private String dateTime;
            private String name;
            private String product;
            private String result;
            #endregion
            #region Properties.
            public String DateTime
            { get { return this.dateTime; } }
            public String Name
            { get { return this.name; } }
            public String Product
            { get { return this.product; } }
            public String Result
            { get { return this.result; } }
            #endregion
            #region Constructors.
            public RunData(String dateTime, String name, String product, String result)
            {
                this.dateTime = dateTime;
                this.name = name;
                this.product = product;
                this.result = result;
            }
            #endregion
      }
