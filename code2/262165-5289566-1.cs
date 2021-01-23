    var footerList = FooterC.ToList();
    
    if (footerList.Count() != 0)
                {
                    foreach (var dataRow in footerList)
                    {
                        FooterText.Value = dataRow.ExtraText;
                    }
                }
                else
                {
                    FooterText.Value = "";
                }
