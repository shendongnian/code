     private void OnCreateFileCommand(object obj)
            {
    
                string path, parameterLabel;
                path = ConfigurationManager.AppSettings["VSSPORTEXELExportPath"];
                parameterLabel = FromDate.ToString("yyyy-MM-dd") + "_" + ToDate.ToString("yyyy-MM-dd");
    
                try
                {
                    path =
                        ExcelUtlity.ExportDataToExcel(
                            dataTable:
                                context.GetDrugUtilizationReport_IndividualGenerateFile(GlobalVar.Pharminfo.pharminfo_PK,
                                    FromDate, ToDate, SelectedDrug != null ? SelectedDrug.drugnameid_PK : 0,
                                    sortBy: SortBy + 1),
                            directoryPath: path,
                            fileName_withoutExt: "DrugUtilizationReport" + "__" + parameterLabel,
                            skipComplexObjects: true,
                            skipInheritedProps: true);
    
                    DXMessageBox.Show("Data exported successfully at \"" + path + "\".", GlobalVar.MessageTitle,
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = ExceptionHelper.ProcessException(ex);
                    DXMessageBox.Show(errorMessage, GlobalVar.MessageTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
    
            }
