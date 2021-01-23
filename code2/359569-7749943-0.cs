                foreach (ListItem  item in cbFilter.Items   )
                {
                    if (item.Selected)
                    {
                        Response.Write(item.Attributes.CssStyle["background-color"].ToString());
                    }
                }
