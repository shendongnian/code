     private void gridFont(ExcelRangeBase eFont, DataGridViewCell dtCell)
        {
            if (eFont.Style.Font.Bold && eFont.Style.Font.Italic && eFont.Style.Font.UnderLine)
            {
                System.Drawing.Font myFont = new System.Drawing.Font(eFont.Style.Font.Name, eFont.Style.Font.Size, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
                dtCell.Style.Font = myFont;
            }
            else
            { 
            if (eFont.Style.Font.Bold && eFont.Style.Font.Italic)
            {
                System.Drawing.Font myFont = new System.Drawing.Font(eFont.Style.Font.Name, eFont.Style.Font.Size, FontStyle.Bold | FontStyle.Italic);
                dtCell.Style.Font = myFont;
            }
            else
                { 
            if (eFont.Style.Font.Bold && eFont.Style.Font.UnderLine)
            {
                System.Drawing.Font myFont = new System.Drawing.Font(eFont.Style.Font.Name, eFont.Style.Font.Size, FontStyle.Bold | FontStyle.Underline);
                dtCell.Style.Font = myFont;
            }
            else
               { 
            if (eFont.Style.Font.Italic && eFont.Style.Font.UnderLine)
            {
                System.Drawing.Font myFont = new System.Drawing.Font(eFont.Style.Font.Name, eFont.Style.Font.Size, FontStyle.Italic | FontStyle.Underline);
                dtCell.Style.Font = myFont;
            }
            else
              { 
                      if (eFont.Style.Font.Bold)
                         {
                            System.Drawing.Font myFont = new System.Drawing.Font(eFont.Style.Font.Name, eFont.Style.Font.Size, FontStyle.Bold);
                            dtCell.Style.Font = myFont;
                        }
                    else
                            {
                                if (eFont.Style.Font.Italic)
                                {
                                    System.Drawing.Font myFont = new System.Drawing.Font(eFont.Style.Font.Name, eFont.Style.Font.Size, FontStyle.Italic);
                                    dtCell.Style.Font = myFont;
                                }
                                else
                                {
                                    if (eFont.Style.Font.UnderLine)
                                    {
                                        System.Drawing.Font myFont = new System.Drawing.Font(eFont.Style.Font.Name, eFont.Style.Font.Size, FontStyle.Underline);
                                        dtCell.Style.Font = myFont;
                                    }
                                }
                            }
                        }
                    }
                }
            }
         }
