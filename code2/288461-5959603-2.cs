       public int getXoffset(HtmlElement el)
         {
             //get element pos
             int xPos = el.OffsetRectangle.Left;
             //get the parents pos
             HtmlElement tempEl = el.OffsetParent;
             while (tempEl != null)
             {
                 xPos += tempEl.OffsetRectangle.Left;
                 tempEl = tempEl.OffsetParent;
             }
              
             return xPos; 
         }  
         public int getYoffset(HtmlElement el)
         {
             //get element pos
             int yPos = el.OffsetRectangle.Top;
             //get the parents pos
             HtmlElement tempEl = el.OffsetParent;
             while (tempEl != null)
             {
                 yPos += tempEl.OffsetRectangle.Top;
                 tempEl = tempEl.OffsetParent;
             }
             return yPos;
         }
