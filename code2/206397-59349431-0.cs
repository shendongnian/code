    public partial class DataGridViewImageButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewImageButtonColumn() : base()
        {
            base.CellTemplate = new DataGridViewImageButtonCell();
        }
        public override object Clone()
        {
            var col = (DataGridViewImageButtonColumn)base.Clone();
            col.Image = Image;
            return col;
        }
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("DataGridViewImageButtonColumn_ImageDescr")]
        public Image Image { get; set; }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !(value.GetType().IsAssignableFrom(typeof(DataGridViewImageButtonCell))))
                {
                    throw new InvalidCastException("Must be a DataGridViewImageButtonCell");
                }
                base.CellTemplate = value;
            }
        }
    }
    public class DataGridViewImageButtonCell : DataGridViewButtonCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value,
             formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            var col = (DataGridViewImageButtonColumn)OwningColumn;
            if (col.Image != null)
                graphics.DrawImage(col.Image, CenterInRectangle(col.Image.Size, cellBounds));
        }
        public static Point CenterInRectangle(Size Inner, Rectangle Outer)
        {
            return new Point()
            {
                X = Outer.X + ((Outer.Width - Inner.Width) / 2),
                Y = Outer.Y + ((Outer.Height - Inner.Height) / 2)
            };
        }
    }
