    protected override void Paint(Graphics graphics,
                Rectangle clipBounds, Rectangle cellBounds,
                int rowIndex, DataGridViewElementStates cellState, object value, object
                formattedValue, string errorText, DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts
                paintParts)
            {
                 if ((value as WhatEverType).WhatEverField == 9)
                 {
                     cellStyle.ForeColor = Color.CornflowerBlue;
                 }
                 base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
