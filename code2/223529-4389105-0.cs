    public class ORDER_LINE_ROW : INullable, IOracleCustomType, IXmlSerializable,IDisposable {
        
        private bool m_IsNull;
        
        private decimal m_AMOUNT;
        
        private bool m_AMOUNTIsNull;
        
        private System.DateTime m_UPDATE_DATE;
        
        private bool m_UPDATE_DATEIsNull;
        
        private string m_FLEXFIELD_1;
        
        private System.DateTime m_INSERT_DATE;
        
        private bool m_INSERT_DATEIsNull;
        
        private string m_FLEXFIELD_3;
        
        private string m_UPDATE_USER;
        
        private string m_FLEXFIELD_2;
        
        private decimal m_ORDER_NO;
        
        private bool m_ORDER_NOIsNull;
        
        private string m_FLEXFIELD_4;
        
        private string m_INSERT_USER;
        
        private decimal m_NO;
        
        private bool m_NOIsNull;
        
        private string m_ITEM_NO;
        
        public ORDER_LINE_ROW() {
            //[07.12.2010]ISMAILH : ISNULLS ARE COMMENTED OUT FOR PROPER WORKING!
            // TODO : Add code to initialise the object
            //this.m_AMOUNTIsNull = true;
            //this.m_UPDATE_DATEIsNull = true;
            //this.m_INSERT_DATEIsNull = true;
            //this.m_ORDER_NOIsNull = true;
            Dispose(false);
            this.m_NOIsNull = true;
        }
        
        public ORDER_LINE_ROW(string str) {
            // TODO : Add code to initialise the object based on the given string 
            Dispose(false);
        }
        
        public virtual bool IsNull {
            get {
                return this.m_IsNull;
            }
        }
        
        public static ORDER_LINE_ROW Null {
            get {
                ORDER_LINE_ROW obj = new ORDER_LINE_ROW();
                obj.m_IsNull = true;
                return obj;
            }
        }
        
        [OracleObjectMappingAttribute("AMOUNT")]
        public decimal AMOUNT {
            get {
                return this.m_AMOUNT;
            }
            set {
                this.m_AMOUNT = value;
            }
        }
        
        public bool AMOUNTIsNull {
            get {
                return this.m_AMOUNTIsNull;
            }
            set {
                this.m_AMOUNTIsNull = value;
            }
        }
        
        [OracleObjectMappingAttribute("UPDATE_DATE")]
        public System.DateTime UPDATE_DATE {
            get {
                return this.m_UPDATE_DATE;
            }
            set {
                this.m_UPDATE_DATE = value;
            }
        }
        
        public bool UPDATE_DATEIsNull {
            get {
                return this.m_UPDATE_DATEIsNull;
            }
            set {
                this.m_UPDATE_DATEIsNull = value;
            }
        }
        
        [OracleObjectMappingAttribute("FLEXFIELD_1")]
        public string FLEXFIELD_1 {
            get {
                return this.m_FLEXFIELD_1;
            }
            set {
                this.m_FLEXFIELD_1 = value;
            }
        }
        
        [OracleObjectMappingAttribute("INSERT_DATE")]
        public System.DateTime INSERT_DATE {
            get {
                return this.m_INSERT_DATE;
            }
            set {
                this.m_INSERT_DATE = value;
            }
        }
        
        public bool INSERT_DATEIsNull {
            get {
                return this.m_INSERT_DATEIsNull;
            }
            set {
                this.m_INSERT_DATEIsNull = value;
            }
        }
        
        [OracleObjectMappingAttribute("FLEXFIELD_3")]
        public string FLEXFIELD_3 {
            get {
                return this.m_FLEXFIELD_3;
            }
            set {
                this.m_FLEXFIELD_3 = value;
            }
        }
        
        [OracleObjectMappingAttribute("UPDATE_USER")]
        public string UPDATE_USER {
            get {
                return this.m_UPDATE_USER;
            }
            set {
                this.m_UPDATE_USER = value;
            }
        }
        
        [OracleObjectMappingAttribute("FLEXFIELD_2")]
        public string FLEXFIELD_2 {
            get {
                return this.m_FLEXFIELD_2;
            }
            set {
                this.m_FLEXFIELD_2 = value;
            }
        }
        
        [OracleObjectMappingAttribute("ORDER_NO")]
        public decimal ORDER_NO {
            get {
                return this.m_ORDER_NO;
            }
            set {
                this.m_ORDER_NO = value;
            }
        }
        
        public bool ORDER_NOIsNull {
            get {
                return this.m_ORDER_NOIsNull;
            }
            set {
                this.m_ORDER_NOIsNull = value;
            }
        }
        
        [OracleObjectMappingAttribute("FLEXFIELD_4")]
        public string FLEXFIELD_4 {
            get {
                return this.m_FLEXFIELD_4;
            }
            set {
                this.m_FLEXFIELD_4 = value;
            }
        }
        
        [OracleObjectMappingAttribute("INSERT_USER")]
        public string INSERT_USER {
            get {
                return this.m_INSERT_USER;
            }
            set {
                this.m_INSERT_USER = value;
            }
        }
        
        [OracleObjectMappingAttribute("NO")]
        public decimal NO {
            get {
                return this.m_NO;
            }
            set {
                this.m_NO = value;
            }
        }
        
        public bool NOIsNull {
            get {
                return this.m_NOIsNull;
            }
            set {
                this.m_NOIsNull = value;
            }
        }
        
        [OracleObjectMappingAttribute("ITEM_NO")]
        public string ITEM_NO {
            get {
                return this.m_ITEM_NO;
            }
            set {
                this.m_ITEM_NO = value;
            }
        }
        
        public virtual void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt) {
            if ((AMOUNTIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "AMOUNT", this.AMOUNT);
            }
            if ((UPDATE_DATEIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "UPDATE_DATE", this.UPDATE_DATE);
            }
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "FLEXFIELD_1", this.FLEXFIELD_1);
            if ((INSERT_DATEIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "INSERT_DATE", this.INSERT_DATE);
            }
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "FLEXFIELD_3", this.FLEXFIELD_3);
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "UPDATE_USER", this.UPDATE_USER);
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "FLEXFIELD_2", this.FLEXFIELD_2);
            if ((ORDER_NOIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "ORDER_NO", this.ORDER_NO);
            }
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "FLEXFIELD_4", this.FLEXFIELD_4);
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "INSERT_USER", this.INSERT_USER);
            if ((NOIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "NO", this.NO);
            }
            Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "ITEM_NO", this.ITEM_NO);
        }
        
        public virtual void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt) {
            this.AMOUNTIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "AMOUNT");
            if ((AMOUNTIsNull == false)) {
                this.AMOUNT = ((decimal)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "AMOUNT")));
            }
            this.UPDATE_DATEIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "UPDATE_DATE");
            if ((UPDATE_DATEIsNull == false)) {
                this.UPDATE_DATE = ((System.DateTime)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "UPDATE_DATE")));
            }
            this.FLEXFIELD_1 = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "FLEXFIELD_1")));
            this.INSERT_DATEIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "INSERT_DATE");
            if ((INSERT_DATEIsNull == false)) {
                this.INSERT_DATE = ((System.DateTime)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "INSERT_DATE")));
            }
            this.FLEXFIELD_3 = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "FLEXFIELD_3")));
            this.UPDATE_USER = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "UPDATE_USER")));
            this.FLEXFIELD_2 = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "FLEXFIELD_2")));
            this.ORDER_NOIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "ORDER_NO");
            if ((ORDER_NOIsNull == false)) {
                this.ORDER_NO = ((decimal)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "ORDER_NO")));
            }
            this.FLEXFIELD_4 = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "FLEXFIELD_4")));
            this.INSERT_USER = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "INSERT_USER")));
            this.NOIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "NO");
            if ((NOIsNull == false)) {
                this.NO = ((decimal)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "NO")));
            }
            this.ITEM_NO = ((string)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "ITEM_NO")));
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader) {
            // TODO : Read Serialized Xml Data
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer) {
            // TODO : Serialize object to xml data
        }
        
        public virtual XmlSchema GetSchema() {
            // TODO : Implement GetSchema
            return null;
        }
        
        public override string ToString() {
            // TODO : Return a string that represents the current object
            return "";
        }
        
        public static ORDER_LINE_ROW Parse(string str) {
            // TODO : Add code needed to parse the string and get the object represented by the string
            return new ORDER_LINE_ROW();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool p)
        {
            if (p == true)
            {
                GC.SuppressFinalize(this);
            }
        }
       
    }
    
    // Factory to create an object for the above class
    [OracleCustomTypeMappingAttribute("ESIPARIS.ORDER_LINE_ROW")]
    public class ORDER_LINE_ROWFactory : IOracleCustomTypeFactory ,IDisposable {
        
        public virtual IOracleCustomType CreateObject() {
            ORDER_LINE_ROW obj = new ORDER_LINE_ROW();
            return obj;
        }
        public void Dispose()
        {
         
        }
    }
