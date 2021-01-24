c#
public class ExcelController : ApiController
{
    [HttpGet]
    [Route("api/file/{id}")]
    public async Task<HttpResponseMessage> DownloadFile(int id)
    {
        var wb = await BuildExcelFile(id);
        return wb.Deliver("excelfile.xlsx");
    }
    private async Task<XLWorkbook> BuildExcelFile(int id)
    {
        //Creating the workbook
        var t = Task.Run(() =>
        {
            var wb = new XLWorkbook();
            var ws = wb.AddWorksheet("Sheet1");
            ws.FirstCell().SetValue(id);
            return wb;
        });
        return await t;
    }
}
Disclaimer: I'm the author.
