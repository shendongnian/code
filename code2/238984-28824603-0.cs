    public class CheckedListBoxColumn : DataGridViewColumn
    {
        public CheckedListBoxColumn()
            : base(new CheckedListBoxCell())
        {
        }
    
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CheckedListBoxCell)))
                {
                    throw new InvalidCastException("Must be a CheckedListBoxCell");
                }
                base.CellTemplate = value;
            }
        }
    }
    
    public class CheckedListBoxCell : DataGridViewCell
    {
        public CheckedListBoxCell()
            : base()
        {
    
        }
    
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.  
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CheckedListBoxEditingControl ctl =
                DataGridView.EditingControl as CheckedListBoxEditingControl;
            InitializeCheckedListBox(ctl, (ICollection)this.FormattedValue);
        }
        private void InitializeCheckedListBox(CheckedListBox ctrl, ICollection value)
        {
            ctrl.Items.Clear();
            foreach (object obj in value)
            {
                ctrl.Items.Add(obj.ToString());
            }
            ctrl.Tag = this.Value;
        }
        public override Type EditType
        {
            get
            {
                return typeof(CheckedListBoxEditingControl);
            }
        }
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null)
            {
                return new List<object>();
            }
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
        public override Type FormattedValueType
        {
            get
            {
                return typeof(ICollection);
            }
        }
        public override Type ValueType
        {
            get
            {
                return typeof(ICollection);
            }
        }
        private CheckedListBox internalControl;
    
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            graphics.FillRectangle(new SolidBrush(cellStyle.BackColor), cellBounds);
    
            if (internalControl == null)
            {
                internalControl = new CheckedListBox();
            }
            internalControl.Items.Clear();
            ICollection collection = value as ICollection;
            if (collection != null)
            {
                foreach (object obj in collection)
                {
                    internalControl.Items.Add(obj);
                }
                Bitmap bmp = new Bitmap(cellBounds.Width, cellBounds.Height);
                internalControl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                graphics.DrawImage(bmp, cellBounds, new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
            }
        }
        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            this.DataGridView.BeginEdit(false);
            base.OnClick(e);
        }
    }
    
    class CheckedListBoxEditingControl : CheckedListBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;
    
        public CheckedListBoxEditingControl()
        {
    
        }
    
        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue   
        // property.  
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Tag;
            }
            set
            {
                //  this.Tag = value;  
            }
        }
    
        // Implements the   
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.  
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }
    
        // Implements the   
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.  
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }
    
        // Implements the IDataGridViewEditingControl.EditingControlRowIndex   
        // property.  
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }
    
        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey   
        // method.  
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.  
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }
    
        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit   
        // method.  
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.  
        }
    
        // Implements the IDataGridViewEditingControl  
        // .RepositionEditingControlOnValueChange property.  
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
    
        // Implements the IDataGridViewEditingControl  
        // .EditingControlDataGridView property.  
    public DataGridView EditingControlDataGridView
    {
        get
        {
            return dataGridView;
        }
        set
        {
            dataGridView = value;
        }
    }
    // Implements the IDataGridViewEditingControl  
    // .EditingControlValueChanged property.  
    public bool EditingControlValueChanged
    {
        get
        {
            return valueChanged;
        }
        set
        {
            valueChanged = value;
        }
    }
    // Implements the IDataGridViewEditingControl  
    // .EditingPanelCursor property.  
    public Cursor EditingPanelCursor
    {
        get
        {
            return base.Cursor;
        }
    }
}    
