     public class LineaBottom : IPdfPTableEvent
    {
        #region IPdfPTableEvent Members
        void IPdfPTableEvent.TableLayout(PdfPTable table, float[][] widths, float[] heights, int headerRows, int rowStart, PdfContentByte[] canvases)
        {
            int columns;
            Rectangle rect;
            int footer = widths.Length - table.FooterRows;
            int header = table.HeaderRows - table.FooterRows + 1;
            int ultima = footer - 1;
            if (ultima != -1)
            {
                columns = widths[ultima].Length - 1;
                rect = new Rectangle(widths[ultima][0], heights[ultima], widths[footer - 1][columns], heights[ultima + 1]);
                rect.BorderColor = BaseColor.BLACK;
                rect.BorderWidth = 1;
                rect.Border = Rectangle.TOP_BORDER;
                canvases[PdfPTable.BASECANVAS].Rectangle(rect);
            }
        }
        #endregion
    }
