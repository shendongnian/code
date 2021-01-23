    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace Project
    {
    	public class DataGridViewLeftCropTextBoxCell : DataGridViewTextBoxCell
    	{
    
    		/// <summary>
    		/// Paints contents
    		/// </summary>
    		/// <param name="graphics"></param>
    		/// <param name="clipBounds"></param>
    		/// <param name="cellBounds"></param>
    		/// <param name="rowIndex"></param>
    		/// <param name="cellState"></param>
    		/// <param name="value"></param>
    		/// <param name="formattedValue"></param>
    		/// <param name="errorText"></param>
    		/// <param name="cellStyle"></param>
    		/// <param name="advancedBorderStyle"></param>
    		/// <param name="paintParts"></param>
    		protected override void Paint( Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts )
    		{
    			string formattedString = formattedValue as string;
    
    			// Nothing to draw
    			if (String.IsNullOrEmpty( formattedString )) {
    				base.Paint( graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts );
    				return;
    			}
    
    			// Draw parently without foreground
    			base.Paint( graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentForeground );
    
    			// No foreground?
    			if ((paintParts & DataGridViewPaintParts.ContentForeground) == DataGridViewPaintParts.None) {
    				return;
    			}
    
    			// Calculate value bounds
    			Rectangle borderWidths = BorderWidths( advancedBorderStyle );
    			Rectangle valBounds = cellBounds;
    			valBounds.Offset( borderWidths.X, borderWidths.Y );
    			valBounds.Width -= borderWidths.Right;
    			valBounds.Height -= borderWidths.Bottom;
    
    			bool cellSelected = (cellState & DataGridViewElementStates.Selected) != 0;
    
    			// Prepare text flags
    			TextFormatFlags flags = ComputeTextFormatFlagsForCellStyleAlignment( this.DataGridView.RightToLeft == RightToLeft.Yes, cellStyle.Alignment, cellStyle.WrapMode );
    			if ((flags & TextFormatFlags.SingleLine) != 0) {
    				flags |= TextFormatFlags.EndEllipsis;
    			}
    
    			// Prepare size of text
    			Size s = TextRenderer.MeasureText( graphics,
    				formattedString,
    				cellStyle.Font
    			);
    
    			// Text fits into bounds, just append
    			if (s.Width < valBounds.Width) {
    				TextRenderer.DrawText( graphics,
    					formattedString,
    					cellStyle.Font,
    					valBounds,
    					cellSelected ? cellStyle.SelectionForeColor : cellStyle.ForeColor,
    					flags );
    				return;
    			}
    
    			// Prepare 
    			StringBuilder truncated = new StringBuilder( formattedString );
    			truncated.Insert( 0, "..." );
    
    			// Truncate the string until it's small enough 
    			while ((s.Width > valBounds.Width) && (truncated.Length > 5)) {
    				truncated.Remove( 3, 1 );
    				formattedString = truncated.ToString();
    				s = TextRenderer.MeasureText( graphics,
    					formattedString,
    					cellStyle.Font
    				);
    			}
    
    			TextRenderer.DrawText( graphics,
    				formattedString,
    				cellStyle.Font,
    				valBounds,
    				cellSelected ? cellStyle.SelectionForeColor : cellStyle.ForeColor,
    				flags
    			);
    		}
    	}
    }
