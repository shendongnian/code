       public ActionResult CmsBulkUploadDownloadExcelSelectedTemplateForGpro(int CmsYear, string TinsList)
        {
            var username = CurrentUser.UserName;
            List<string> TinList = TinsList.Split('|').ToList();
            DataTable dt = new DataTable();
            if (TinList.Count <= 0)
            {
                // Need Select Aleast one Tin
            }
            else
            {
                dt.Columns.Add("Tin", typeof(string));
                foreach (var item in TinList)
                {
                    DataRow dr = dt.NewRow();
                    dr["Tin"] = item;
                    dt.Rows.Add(dr);
                }
            }
            List<CMSFacilityData> list = new List<CMSFacilityData>();
            list = FacilityCMSSubmissionBL.GetQMSelectedTinsMeasures(CmsYear, dt)
            ViewBag.ex = "";
            var iteratecount = Math.Ceiling(Convert.ToDecimal(list.Count) / 4);
            var skip = 0;
            var next = 4;
            for (int x = 0; x < iteratecount; x++)
            {
                try
                {
        
                var list1 = list.Skip(skip).Take(next).ToList();
      
                string myName = Server.UrlEncode("MIPS" + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss-") + Convert.ToString(x+1)+".xlsx");
                var strAppPath = System.Web.HttpRuntime.AppDomainAppVirtualPath.ToString();
                if (strAppPath == "/")
                {
                    strAppPath = "";
                }
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("PQRS Excel Data");
                // This is to ensure that this column is text
                worksheet.Column(1).Style.NumberFormat.Format = "@";
                worksheet.Column(2).Style.NumberFormat.Format = "@";
                worksheet.Column(3).Style.NumberFormat.Format = "@";
                worksheet.Column(4).Style.NumberFormat.Format = "@";
                worksheet.Column(5).Style.NumberFormat.Format = "@";
                worksheet.Column(6).Style.NumberFormat.Format = "@";
                worksheet.Column(7).Style.NumberFormat.Format = "@";
                worksheet.Column(8).Style.NumberFormat.Format = "@";
                worksheet.Column(9).Style.NumberFormat.Format = "@";
                worksheet.Column(10).Style.NumberFormat.Format = "@";
                worksheet.Column(11).Style.NumberFormat.Format = "@";
                worksheet.Column(12).Style.NumberFormat.Format = "@";
                worksheet.Column(13).Style.NumberFormat.Format = "@";
                /// worksheet.Column(13).Style.NumberFormat.Format = "@";
                //worksheet.Column(10).Style.NumberFormat.Format = "@";
                //  worksheet.Column(1).Style.NumberFormat.Format = "mm/dd/yyyy hh:mm:ss";
                var i = 1; //max 1048576
                do
                {
                    var r = worksheet.Row(i);
                    for (int c = 1; c < 14; c++)
                    {
                        r.Cell(c).SetDataType(XLCellValues.Text);
                        // r.Cell(c).SetValue("");
                        var j = i - 1;
                        switch (c)
                        {
                            case 1:
                                //TIN 1
                                r.Cell(c).SetValue(Convert.ToString(list1[j].TINNum));
                                break;
                            case 2:
                                ///Measure Number -2
                                r.Cell(c).SetValue(Convert.ToString(list1[j].Mes_Number));
                                break;
                            case 3:
                                ///Total_numberof_Exams_mygroup_performed -3
                                r.Cell(c).SetValue(Convert.ToString(list1[j].measCount));
                                break;
                            case 4:
                                ///Number_of_Exams_Submitted_OLD -4
                                r.Cell(c).SetValue(Convert.ToString(list1[j].RecordsCount));
                                break;
                            case 5:
                                ///Number_of_Exams_Submitted_NEW -5
                                r.Cell(c).SetValue("");
                                break;
                            case 6:
                                ///Submitted_Hundred_Percent_OLD -6
                                r.Cell(c).SetValue(Convert.ToString(list1[j].HundredPercentOfSubmit != null ? (list1[0].HundredPercentOfSubmit == true ? "Y" : "N") : ""));
                                break;
                            case 7:
                                ///Submitted_Hundred_Percent_NEW -7
                                r.Cell(c).SetValue("");
                                break;
                            case 8:
                                ///Selected_for_CMS_submission_OLD -8
                                r.Cell(c).SetValue(Convert.ToString(list1[j].SelectedForCMS != null ? (list1[0].SelectedForCMS == true ? "Y" : "N") : ""));
                                break;
                            case 9:
                                ///Selected_for_CMS_submission_NEW -9
                                r.Cell(c).SetValue("");
                                break;
                            case 10:
                                ///Performance_rate -10
                                r.Cell(c).SetValue(Convert.ToString(list1[j].Performance_rate));
                                break;
                            case 11:
                                ///Decile -11
                                r.Cell(c).SetValue(Convert.ToString(list1[j].Decile_Val));
                                break;
                            case 12:
                                ///Completeness -12
                                r.Cell(c).SetValue(Convert.ToString(list1[j].Reporting_Rate));
                                break;
                            case 13:
                                ///isEndtoEndReported -12
                                r.Cell(c).SetValue(Convert.ToString(list1[j].isEndtoEndReported == true ? "Y" : "N"));
                                break;
                            default:
                                break;
                        }
                    }
                    i++;
                } while (i < list1.Count);
                var k = list1.Count;
                if (list1.Count <= 100000)
                    do
                    {
                        var r = worksheet.Row(k);
                        for (int c = 1; c < 13; c++)
                        {
                            r.Cell(c).SetDataType(XLCellValues.Text);
                            r.Cell(c).SetValue("");
                        }
                        k++;
                    }
                    while (k < 100000);
                worksheet.Cell("A1").Value = "TIN";
                worksheet.Cell("B1").Value = "Measure_Number";
                worksheet.Cell("C1").Value = "Total_numberof_Exams_mygroup_performed";
                worksheet.Cell("D1").Value = "Number_of_Exams_Submitted_OLD";
                worksheet.Cell("E1").Value = "Number_of_Exams_Submitted_NEW";
                worksheet.Cell("F1").Value = "Submitted_Hundred_Percent_OLD";
                worksheet.Cell("G1").Value = "Submitted_Hundred_Percent_NEW";
                worksheet.Cell("H1").Value = "Selected_for_CMS_submission_OLD";
                worksheet.Cell("I1").Value = "Selected_for_CMS_submission_NEW";
                worksheet.Cell("J1").Value = "Performance_rate";
                worksheet.Cell("K1").Value = "Decile";
                worksheet.Cell("L1").Value = "Completeness";
                worksheet.Cell("M1").Value = "EndtoEndReporting";
                //worksheet.Cell("M1").Value = "Measure_Extension_Num";
                //worksheet.Cell("N1").Value = "Extension_Response_Value";
                //worksheet.Cell("O1").Value = "Exam_Unique_ID";
                worksheet.Columns().AdjustToContents();
                MemoryStream stream = new MemoryStream();
            
                stream=(MemoryStream)GetStream(workbook);
                Response.Clear();
               
                 Response.ClearContent();
                    Response.ClearHeaders();
               
                    Response.Buffer = true;
                     Response.AddHeader("content-disposition", "attachment; filename=" + myName);
                    Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    //Response.Clear();
                    Response.End();
                    Response.Buffer = false;
                    stream.Dispose();
                stream.Close();
                
                
                    //workbook.Dispose();
                    skip = skip + 4;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return PartialView("_BulkCmsDataFileUpload");
        } 
