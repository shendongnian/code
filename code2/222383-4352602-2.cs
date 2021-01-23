    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Windows.Forms.VisualStyles;
    
    namespace HideMainWinForm
    {
      class DataGridViewReviewerCell : DataGridViewCell
      {
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
          return value;
        }
    
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
          if (paintParts.HasFlag(DataGridViewPaintParts.Background))
          {
            using (SolidBrush cellBackground =
              new SolidBrush(cellStyle.BackColor))
            {
              graphics.FillRectangle(cellBackground, cellBounds);
            }
          }
    
          if (paintParts.HasFlag(DataGridViewPaintParts.Border))
          {
            PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
              advancedBorderStyle);
          }
    
          if (value != null)
          {
            CheckBoxRenderer.DrawCheckBox(
              graphics,
              new Point(cellBounds.X + 4, cellBounds.Y + 4),
              new Rectangle(cellBounds.X+24,cellBounds.Y+4, cellBounds.Width-24, cellBounds.Height-4),
              formattedValue.ToString(),
              OwningColumn.InheritedStyle.Font,
              TextFormatFlags.Left,
              false,
              CheckBoxState.CheckedNormal);
          }
        }
      }
    }
