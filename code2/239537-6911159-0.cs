    public void ExportToExcel<T>(List<T> list)
        {
            int columnCount = 0;
           
            DateTime StartTime = DateTime.Now;
            StringBuilder rowData = new StringBuilder();
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            rowData.Append("<Row ss:StyleID=\"s62\">");
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.Name != "EntityCollection`1" && p.PropertyType.Name != "EntityReference`1" && p.PropertyType.Name != p.Name)
                {
                    columnCount++;
                    rowData.Append("<Cell><Data ss:Type=\"String\">" + p.Name + "</Data></Cell>");
                }
                else
                    break;
            }
            rowData.Append("</Row>");
            foreach (T item in list)
            {                
                rowData.Append("<Row>");
                for (int x = 0; x < columnCount; x++) //each (PropertyInfo p in properties)
                {                    
                    object o = properties[x].GetValue(item, null);
                    string value = o == null ? "" : o.ToString();                    
                    rowData.Append("<Cell><Data ss:Type=\"String\">" + value + "</Data></Cell>");
                }
                rowData.Append("</Row>");
            }
            var sheet = @"<?xml version=""1.0""?>
                        <?mso-application progid=""Excel.Sheet""?>
                        <Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""
                            xmlns:o=""urn:schemas-microsoft-com:office:office""
                            xmlns:x=""urn:schemas-microsoft-com:office:excel""
                            xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""
                            xmlns:html=""http://www.w3.org/TR/REC-html40"">
                            <DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">
                                <Author>MSADMIN</Author>
                                <LastAuthor>MSADMIN</LastAuthor>
                                <Created>2011-07-12T23:40:11Z</Created>
                                <Company>Microsoft</Company>
                                <Version>12.00</Version>
                            </DocumentProperties>
                            <ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">
                                <WindowHeight>6600</WindowHeight>
                                <WindowWidth>12255</WindowWidth>
                                <WindowTopX>0</WindowTopX>
                                <WindowTopY>60</WindowTopY>
                                <ProtectStructure>False</ProtectStructure>
                                <ProtectWindows>False</ProtectWindows>
                            </ExcelWorkbook>
                            <Styles>
                                <Style ss:ID=""Default"" ss:Name=""Normal"">
                                    <Alignment ss:Vertical=""Bottom""/>
                                    <Borders/>
                                    <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""/>
                                    <Interior/>
                                    <NumberFormat/>
                                    <Protection/>
                                </Style>
                                <Style ss:ID=""s62"">
                                    <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""
                                        ss:Bold=""1""/>
                                </Style>
                            </Styles>
                            <Worksheet ss:Name=""Sheet1"">
                                <Table ss:ExpandedColumnCount=""" + (properties.Count() + 1) + @""" ss:ExpandedRowCount=""" + (list.Count() + 1) + @""" x:FullColumns=""1""
                                    x:FullRows=""1"" ss:DefaultRowHeight=""15"">
                                    " + rowData.ToString() +@"
                                </Table>
                                <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">
                                    <PageSetup>
                                        <Header x:Margin=""0.3""/>
                                        <Footer x:Margin=""0.3""/>
                                        <PageMargins x:Bottom=""0.75"" x:Left=""0.7"" x:Right=""0.7"" x:Top=""0.75""/>
                                    </PageSetup>
                                    <Print>
                                        <ValidPrinterInfo/>
                                        <HorizontalResolution>300</HorizontalResolution>
                                        <VerticalResolution>300</VerticalResolution>
                                    </Print>
                                    <Selected/>
                                    <Panes>
                                        <Pane>
                                            <Number>3</Number>
                                            <ActiveCol>2</ActiveCol>
                                        </Pane>
                                    </Panes>
                                    <ProtectObjects>False</ProtectObjects>
                                    <ProtectScenarios>False</ProtectScenarios>
                                </WorksheetOptions>
                            </Worksheet>
                            <Worksheet ss:Name=""Sheet2"">
                                <Table ss:ExpandedColumnCount=""1"" ss:ExpandedRowCount=""1"" x:FullColumns=""1""
                                    x:FullRows=""1"" ss:DefaultRowHeight=""15"">
                                </Table>
                                <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">
                                    <PageSetup>
                                        <Header x:Margin=""0.3""/>
                                        <Footer x:Margin=""0.3""/>
                                        <PageMargins x:Bottom=""0.75"" x:Left=""0.7"" x:Right=""0.7"" x:Top=""0.75""/>
                                    </PageSetup>
                                    <ProtectObjects>False</ProtectObjects>
                                    <ProtectScenarios>False</ProtectScenarios>
                                </WorksheetOptions>
                            </Worksheet>
                            <Worksheet ss:Name=""Sheet3"">
                                <Table ss:ExpandedColumnCount=""1"" ss:ExpandedRowCount=""1"" x:FullColumns=""1""
                                    x:FullRows=""1"" ss:DefaultRowHeight=""15"">
                                </Table>
                                <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">
                                    <PageSetup>
                                        <Header x:Margin=""0.3""/>
                                        <Footer x:Margin=""0.3""/>
                                        <PageMargins x:Bottom=""0.75"" x:Left=""0.7"" x:Right=""0.7"" x:Top=""0.75""/>
                                    </PageSetup>
                                    <ProtectObjects>False</ProtectObjects>
                                    <ProtectScenarios>False</ProtectScenarios>
                                </WorksheetOptions>
                            </Worksheet>
                        </Workbook>";
            System.Diagnostics.Debug.Print(StartTime.ToString() + " - " + DateTime.Now);
            System.Diagnostics.Debug.Print((DateTime.Now - StartTime).ToString());
            string attachment = "attachment; filename=Report.xml";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.Write(sheet);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.End();
        }
