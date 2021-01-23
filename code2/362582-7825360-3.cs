    #region schedule column
    [PersistChildren(true)]
    public sealed class ScheduleGridColumn : DataGridColumn, INamingContainer
    {
        #region private member variables
        private bool editModeEnabled;
        private bool aggregateColumn;        
        private string uniqueName;
        private string dataFieldName;
        private string aggregateKey;
        private string dataFormatString;
        private ITemplate editTemplate = null;
        #endregion
        #region constructor
        /// <summary>
        /// Initializes the GridColumn object using default values.
        /// </summary>
        public ScheduleGridColumn()
        {
            //initialize other fields to defaults
            dataFieldName = String.Empty;
            dataFormatString = String.Empty;
            uniqueName = String.Empty;
            //disable edit mode by default
            editModeEnabled = false;
        }
        #endregion
        #region properties
        /// <summary>
        /// Gets or sets the edit template.
        /// </summary>      
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        PersistenceMode(PersistenceMode.InnerProperty),
        TemplateInstance(TemplateInstance.Single)]
        public ITemplate EditTemplate
        {
            get
            {
                return editTemplate;
            }
            set
            {
                editTemplate = value;
            }
        }
        /// <summary>
        /// Gets or sets the unique name.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string UniqueName
        {
            get
            {
                return uniqueName;
            }
            set
            {
                uniqueName = value;
            }
        }
        /// <summary>
        /// Gets or sets the name of the data field.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DataField
        {
            get
            {
                return dataFieldName;
            }
            set
            {
                dataFieldName = value;
            }
        }
        /// <summary>
        /// Gets or sets the format string used to format the data.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DataFormatString
        {
            get
            {
                return dataFormatString;
            }
            set
            {
                dataFormatString = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the item 
        /// is in edit mode.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EditModeEnabled
        {
            get
            {
                return editModeEnabled;
            }
            set
            {
                editModeEnabled = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the item should be aggregated.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AggregateColumn
        {
            get
            {
                return aggregateColumn;
            }
            set
            {
                aggregateColumn = value;
            }
        }
        /// <summary>
        /// Gets or sets the aggregate key.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string AggregateKey
        {
            get
            {
                return aggregateKey;
            }
            set
            {
                aggregateKey = value;
            }
        }
        #endregion
    }
    #endregion
