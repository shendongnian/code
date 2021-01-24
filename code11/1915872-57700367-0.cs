     public sealed class Participant
    {
        #region Attributes
        public int _ParticipantId;
        public string _Forename;
        public string _Name;
        public List<Model.Discipline> Disciplines;
        #endregion
        #region Properties
        public int ParticipantId
        {
            get
            {
                return _ParticipantId;
            }
            set
            {
                _ParticipantId = value;
            }
        }
        public string Forename
        {
            get
            {
                return _Forename;
            }
            set
            {
                _Forename = value;
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
        #endregion
        #region Constructors
        public Participant(): base()
        {
            ParticipantId = 0;
            Forename = string.Empty;
            Name = string.Empty;
            Disciplines = null;
        }
        public Participant(DataRow dr) : base()
        {
            InitFromDB(dr);
        }
        #endregion
        public void InitFromDB(DataRow dr)
        {
            if (DBNull.Value != (dr["ParticipantId"]))
                ParticipantId = Convert.ToInt32(dr["ParticipantId"]);
            if (DBNull.Value != (dr["Forename"]))
                Forename = Convert.ToString(dr["Forename"]);
            if (DBNull.Value != (dr["Name"]))
                Name = Convert.ToString(dr["Name"]);
        }
    }
