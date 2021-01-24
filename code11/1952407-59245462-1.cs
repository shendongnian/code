    DataTable dt = new DataTable();
            string Secteur, Reference, Title, DateLimite, DatePublication, Lieux;
            dt.Columns.Add("Secteur", typeof(string));
            dt.Columns.Add("Reference", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("DateLimite", typeof(string));
            dt.Columns.Add("DatePublication", typeof(string));
            dt.Columns.Add("Lieux", typeof(string));
           
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = web.Lists["Offres"];
                        
                        SPListItemCollection coll = list.Items;
                        foreach (SPListItem item in coll)
                        {
                            if (item["Secteur"] != null)
                            {
                                Secteur = item["Secteur"].ToString();
                            }
                            else
                            {
                                Secteur = "";
                            }
                            if (item["Reference"] != null)
                                Reference = item["Reference"].ToString();
                            else
                                Reference = " ";
                            if (item["Title"] != null)
                                Title = item["Title"].ToString();
                            else
                                Title = " ";
                            if (item["DateLimite"] != null)
                                DateLimite = item["DateLimite"].ToString();
                            else
                                DateLimite = " ";
                            if (item["DatePublication"] != null)
                                DatePublication = item["DatePublication"].ToString();
                            else
                                DatePublication = " ";
                            if (item["Lieux"] != null)
                                Lieux = item["Lieux"].ToString();
                            else
                                Lieux = " ";
                            dt.Rows.Add(Secteur, Reference, Title, DateLimite, 
                              DatePublication, Lieux);
                        }
                        OffresGrid.DataSource = dt;
                        OffresGrid.DataBind();
                    }
                }
            }
            catch (Exception )
            {
            }
