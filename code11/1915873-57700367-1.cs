     public sealed class Discipline
    {
        #region Attributes
        public int _DisciplineId;
        public string _Name;
        public int _Result1;
        public int _Result2;
        public int _Result3;
        #endregion
        #region Properties
        public int DisciplineId
        {
            get
            {
                return _DisciplineId;
            }
            set
            {
                _DisciplineId = value;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public int Result1
        {
            get
            {
                return _Result1;
            }
            set
            {
                _Result1 = value;
            }
        }
        public int Result2
        {
            get
            {
                return _Result2;
            }
            set
            { 
                _Result2 = value;
            }
        }
        public int Result3
        {
            get
            {
                return _Result3;
            }
            set
            {
                _Result3 = value;
            }
        }
        #endregion
        #region Constructors
        public Discipline() : base()
        {
            DisciplineId = 0;
            Name = string.Empty;
            Result1 = 0;
            Result2 = 0;
            Result3 = 0;
        }
        public Discipline(DataRow dr) : base()
        {
            InitFromDB(dr);
        }
        #endregion
        public void InitFromDB(DataRow dr)
        {
            if (DBNull.Value != (dr["DisciplineId"]))
                DisciplineId = Convert.ToInt32(dr["DisciplineId"]);
            if (DBNull.Value != (dr["Name"]))
                Name = Convert.ToString(dr["Name"]);
            if (DBNull.Value != (dr["Result1"]))
                Result1 = Convert.ToInt32(dr["Result1"]);
            if (DBNull.Value != (dr["Result2"]))
                Result2 = Convert.ToInt32(dr["Result2"]);
            if (DBNull.Value != (dr["Result3"]))
                Result3 = Convert.ToInt32(dr["Result3"]);
        }
    }
