        public SPOEReview GetFileDetailsForSPOEReview(int fileUploadId)
        {         
		var spoeFileToReview.SubmittedTemplate = GetTemplateDetails(spoeFileToReview.ApprovalTemplateName, spoeFileToReview.Year);
            if (spoeFileToReview.SubmittedTemplate.Rows.Count > 0 && spoeFileToReview.ExistingTemplate.Rows.Count > 0)
            {
                List<DataRow> lstNewRows = spoeFileToReview.SubmittedTemplate.AsEnumerable().Except(
                        spoeFileToReview.ExistingTemplate.AsEnumerable(),
                                                  DataRowComparer.Default).ToList();
                var lstRowsExcludingNew = spoeFileToReview.SubmittedTemplate.AsEnumerable().Except(
                              lstNewRows.AsEnumerable(),
                                                        DataRowComparer.Default).ToList();
                // Existing table:
                if (lstRowsExcludingNew != null && lstRowsExcludingNew.Count > 0)
                {
                    DataTable dtFinalForExistingTemplates = lstRowsExcludingNew.CopyToDataTable();
                    spoeFileToReview.ExistingTemplate = dtFinalForExistingTemplates;
                }
                // Submitted table:
                if (lstNewRows != null && lstNewRows.Count > 0)
                {
                    List<DataRow> rowCollection = lstRowsExcludingNew;
                    rowCollection.AddRange(lstNewRows);
                    DataTable dtFinalForSubmittedTemplates = rowCollection.CopyToDataTable();
                    spoeFileToReview.SubmittedTemplate = dtFinalForSubmittedTemplates;
                }
				//This is to get the additional columns of the submitted table if any
                var submittedTemplatesWithAdditionalColumns = spoeFileToReview.ExistingTemplate.Columns.Cast<DataColumn>()
                            .Select(x => x.ColumnName)
                            .ToArray();
                spoeFileToReview.AdditionalColumns = spoeFileToReview.SubmittedTemplate.Columns.Cast<DataColumn>()
                                    .Where(x => !submittedTemplatesWithAdditionalColumns.Contains(x.ColumnName))
                                     .Select(x => x.ColumnName)
                                    .ToList();
            }
            return spoeFileToReview;
        }
