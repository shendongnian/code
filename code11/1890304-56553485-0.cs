    [FunctionName("ConvertExcelToCSV")]
        public static async Task RunAsync(
            [BlobTrigger("excel-files/{blobName}")] Stream excelFileInput,
            [Blob("csv-files/{blobName}", FileAccess.Write)] Stream csvFileOutput,
            CancellationToken token,
            ILogger log)
        {
            log.LogInformation($"Do your processing on the excelFileInput file here.");
            //Do your processing on another steam. Maybe, MemoryStream
            await memoryStream.CopyToAsync(csvFileOutput, 4096, token);
        }
