public class CounterViewComponent: ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(MyModel model)
    {
        // magic here
        return View(model);
    }
}
3. Call it in your view:
@await Component.InvokeAsync("Counter", new { model = Model })
