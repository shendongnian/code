            try
            {
                DataSet ds = new DataSet();
                ds = businesscase.services.Actuals.GetActualsGridData(bcid, cmd);
                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        // instantiate a datagrid 
                        GridView gvExcel = new GridView();
                        gvExcel.RowDataBound += new GridViewRowEventHandler(this.gvExcel_RowDataBound);
                        gvExcel.DataSource = ds.Tables[0];
                        gvExcel.DataBind();
                        gvExcel.RenderControl(htw);
                        response.Write("<style> .cost{mso-number-format:\"\\#\\#0\\.00\";} </style>");
                        //response.Write(style);
                        response.Write(sw.ToString());
                        response.End();
                    }
                }
            }
            catch
            {
            }
