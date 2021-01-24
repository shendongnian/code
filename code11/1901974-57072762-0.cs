    void datagridview_CellPainting(object sender,DataGridViewCellPaintingEventArgs e)
    {
      if(datagridview.Columns[e.ColumnsIndex].Name=="content")
      {
          string content="this is a test message,to illustrate this words fine";
          string []line=content.Split(',');
          StringFormat sf=new StringFormat();
          sf.Alignment=StringAlignment.Center;
          sf.LineAlignment=StringAlignment.Center; 
 
          e.Paint(e.CellBounds, DataGridViewPaintParts.All&~DataGridViewPaintParts.ContentForeground);
          SizeF []size=new SizeF[line.Length];
          for(int i=0;i<line.Length;++i)
          {
              size[i]=e.Graphics.MeasureString(line[i],e.CellStyle.Font);
          }
          RectangleF rec=new RectangleF(e.CellBounds.Location,new Size(0,0));
          using(SolidBrush bblack=new SolidBrush(Color.Black),bred=new 
                                                        SolidBrush(Color.Red))
          {
               for(int i=0;i<line.Length;++i)
               {
                   rec=new RectangleF(new 
                           PointF(rec.Location.X+rec.Width,rec.Location.Y),new 
                                  SizeF(size[i].Width,e.CellBounds.Height));
                   if(i%2==0)
                   {                  
                        e.Graphics.DrawString(line[i], e.CellStyle.Font, bred, rec, sf);
                   }
                   else
                   {
                        e.Graphics.DrawString(line[i].e.CellStyle.Font, bblack, rec, sf);
                   }
               }
          }
          e.Handled=true;
      }
    }
