csharp
[MiddlewareFilter(typeof(JsReportPipeline))]
public async Task<IActionResult> InvoiceWithHeader()
{
    var header = await JsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Header", new { });
    HttpContext.JsReportFeature()
        .Recipe(Recipe.ChromePdf)
        .Configure((r) => r.Template.Chrome = new Chrome {
            HeaderTemplate = header,
            DisplayHeaderFooter = true,
            MarginTop = "1cm",
            MarginLeft = "1cm",
            MarginBottom = "1cm",
            MarginRight = "1cm"
        });
    return View("Invoice", InvoiceModel.Example());
}
