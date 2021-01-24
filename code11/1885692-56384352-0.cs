        /// <summary>
        /// Converts an uploaded Excel file (multipart) to a JSON object. Useful for converting large Excel files instead
        /// of doing so in the browser, due to performance issues with SheetJS JavaScript library.
        /// </summary>
        [HttpPost]
        [Route("ConvertedFile")]
        [SwaggerResponse(HttpStatusCode.OK, "Success", typeof(List<Dictionary<string, object>>))]
        public async Task<IHttpActionResult> GetConvertedFile()
        {            
            var fileData = await processUploadFile();
            fileData = removeEmptyRows(fileData);
            return Ok(fileData);
        }
        
        /// <summary>
        /// Converts an uploaded Excel file (multipart) to a JSON object. Sends the file to be processed.
        /// </summary>
        [HttpPost]
        [Route("")]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "Success")]
        public Task<IHttpActionResult> UploadExcelFile()
        {            
            var uploadFileData = await processUploadFile();
            
            // Do something with uploadFileData...
            return Ok();
        }
        
        /// <summary>
        /// Processes the upload file by converting uploaded Excel file (XLSX) to "JSON" object.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        private async Task<List<Dictionary<string, object>>> processUploadFile()
        {
            var documentData = new List<Dictionary<string, object>>();
            
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                // Manage the multipart file in memory, not on the file system
                MultipartMemoryStreamProvider streamProvider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(streamProvider);
                // Should have only one "content" or file.
                HttpContent content = streamProvider.Contents.FirstOrDefault();
                // Convert the HttpContent to a Stream
                using (Stream fileUploadStream = await content.ReadAsStreamAsync())
                {
                    // Convert the Excel file stream to a List of "rows"
                    documentData = ExcelManager.ExcelDataReader(fileUploadStream);
                    if (documentData != null)
                    {
                        // header rows are not represented in the Values.
                        Log.Information("Order Data - Processed {0} lines of file data", documentData.Count);
                    }
                    else
                    {
                        Log.Warning("File processing error. No data.");
                    }
                }
                sw.Stop();
                Log.Debug("Excel File took {0} ms", sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("Test File Processing error."));
                throw;
            }
            return documentData;
        }
        /// <summary>
        /// Removes the empty rows.
        /// </summary>
        /// <param name="documentData">
        /// Represent a list of excel rows. Each list item represent a row. Each Dictionary key represent the column
        /// name. Dictionary value represent cell value.
        /// </param>
        /// <returns></returns>
        private List<Dictionary<string, object>> removeEmptyRows(List<Dictionary<string, object>> documentData)
        {
            // build a new collection that only contains rows that have at least one column with a value
            List<Dictionary<string, object>> nonEmptyRows = new List<Dictionary<string, object>>();
            if (documentData != null && documentData.Count > 0)
            {
                // evaluate each item in the list
                foreach (var item in documentData)
                {
                    bool isRowEmpty = false;
                    // evaluate each Key/Value pair.
                    // RowID, State, and Message are the fields added to the document for state tracking.
                    // Do not consider those fields.
                    foreach (var key in item.Keys)
                    {
                        if (key != "RowID" && key != "State" && key != "Message")
                        {
                            var value = item[key];
                            Type type = value.GetType();
                            isRowEmpty = type.Name == "DBNull";
                        }
                        // if an non-null value is found within the current row then stop processing this item and
                        // continue on to the next item (excel row).
                        if (!isRowEmpty)
                        {
                            break;
                        }
                    }
                    // if the row has user supplied data then include it 
                    if (!isRowEmpty)
                    {
                        nonEmptyRows.Add(item);
                    }
                }
                Log.Information("Removed {0} empty rows from excel File", documentData.Count - nonEmptyRows.Count);
            }
            return nonEmptyRows;
        }
    using Excel;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    public static class ExcelManager
    {
        /// <summary>
        /// Read the steam file to convert it into a list of dictionaries
        /// </summary>
        /// <param name="fileUploadStream">The file stream</param>
        /// <param name="columnNames">The column names to be read in the excel file</param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> ExcelDataReader(Stream fileUploadStream)
        {
            List<Dictionary<string, object>> docData = new List<Dictionary<string, object>>();
            IExcelDataReader excelReader = null;
            try
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileUploadStream);
                // Columns names are not handled
                excelReader.IsFirstRowAsColumnNames = true;
                bool isEmpty = isFileEmpty(excelReader);
                if (!isEmpty)
                {
                    // note: files that have only the header row will throw an exception when AsDataSet is called.
                    DataSet ds = excelReader.AsDataSet();
                    
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Dictionary<string, object> data = new Dictionary<string, object>();
                        foreach (DataColumn col in ds.Tables[0].Columns)
                        {
                            data[col.ColumnName] = row[col];
                        }
                        //This filter duplicates inserts with the same OrderLinkId
                        if ((docData.Exists(e => e.Values.ElementAt(0).Equals(data.Values.ElementAt(0)) && e.Values.ElementAt(1).Equals(data.Values.ElementAt(1))) == false))
                        {
                            docData.Add(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "");
                throw;
            }
            finally
            {
                excelReader.Close();
            }
            return docData;
        }
        /// <summary>
        /// Verifies the file has at least one row of data. No header fields are used in the file.
        /// </summary>
        /// <param name="excelReader">The excel reader.</param>
        /// <returns></returns>
        private static bool isFileEmpty(IExcelDataReader excelReader)
        {
            try
            {
                while (excelReader.Read())
                {
                    return false;
                }
            }
            catch (Exception)
            {
                // swallow this exception.
            }
            return true;
        }
    }
