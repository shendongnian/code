            pdfdoc.ReportState = ReportStateConstants.acReportStateDesign;
            object[] page_items = (object[])pdfdoc.get_ObjectAttribute("Pages[1]", "Objects");
            string[] color_attributes = new string[] { "TextColor", "BackColor", "BorderColor", "StrokeColor" };
            foreach (acObject page_item in page_items)
            {
                object _type = page_item["ObjectType"];
                if ((ACPDFCREACTIVEX.ObjectTypeConstants)_type == ACPDFCREACTIVEX.ObjectTypeConstants.acObjectTypePicture)
                {
                    page_item["GrayScale"] = true;
                }
                else
                    foreach (string attr_name in color_attributes)
                    {
                        try
                        {
                            Color color = System.Drawing.ColorTranslator.FromWin32((int)page_item[attr_name]);
                            int grayColor = (int)(0.3 * color.R + 0.59 * color.G + 0.11 * color.B);
                            int newColorRef = System.Drawing.ColorTranslator.ToWin32(Color.FromArgb(grayColor, grayColor, grayColor));
                            page_item[attr_name] = newColorRef;
                        }
                        catch { } //not all items have all kinds of color attributes
                    }
            }
