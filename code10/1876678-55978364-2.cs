    using System.Drawing;
    using System.Windows.Forms;
    class DGVCustomImageColumn : DataGridViewImageColumn
    {
        private Bitmap dgvErrorBitmap = new Bitmap(1, 1);
        public DGVCustomImageColumn()
            : this("ImageColumn", "ImageColumn", string.Empty, null) { }
        public DGVCustomImageColumn(string colName, string headerText)
            : this(colName, headerText, string.Empty, null) { }
        public DGVCustomImageColumn(string colName, string headerText, string dataField)
            : this(colName, headerText, dataField, null) { }
        public DGVCustomImageColumn(string colName, string headerText, string dataField, Bitmap errorImage)
        {
            this.CellTemplate = new CustImageCell(errorImage ?? dgvErrorBitmap);
            this.DataPropertyName = dataField;
            this.HeaderText = headerText;
            this.Image = errorImage ?? dgvErrorBitmap;
            this.Name = colName;
        }
        protected class CustImageCell : DataGridViewImageCell
        {
            public CustImageCell() : this(null) { }
            public CustImageCell(Bitmap defaultImage) => this.DefaultNewRowValue = defaultImage;
            public override object DefaultNewRowValue { get; }
        }
    }
