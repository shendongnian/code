@model App.TagHelpers.PartialVM
@{ 
    var PartialHtml = Model.HtmlHelper;
}
@PartialHtml.Label(Model.NewFor.Name,Model.NewFor.Name) 
@PartialHtml.TextBox(Model.NewFor.Name, Model.NewModel)
Namely, use `@Html.Label()` & `@Html.TextBot` rather than `<label>` & `<input>`. 
Here the `PartialVM` is a simple class that holds the meta info about the model :
csharp
public class PartialVM
{
    public PartialVM(ModelExpression originalFor, IHtmlHelper htmlHelper)
    {
        var originalExplorer = originalFor.ModelExplorer;
        OriginalFor = originalFor;
        OriginalExplorer = originalExplorer;
        NewModel = originalExplorer.Model;
        NewModelExplorer = originalExplorer.GetExplorerForModel(NewModel);
        NewFor = new ModelExpression(OriginalFor.Name, NewModelExplorer);
        this.HtmlHelper = htmlHelper;
    }
    public IHtmlHelper HtmlHelper { get; set; }
    public ModelExpression OriginalFor { get; set; }
    public ModelExplorer OriginalExplorer { get; set; }
    public ModelExpression NewFor { get; set; }
    public ModelExplorer NewModelExplorer { get; set; }
    public Object NewModel { get; set; }
}
Note the `IHtmlHelper` is actually an **`IHtmlHelper<TSomeDynamicModel>` instead of a plain `IHtmlHelper`** .
Lastly, change your `TagHelper` as below:
    [HtmlTargetElement("my-custom-input")]
    public class MyCustomInputTagHelper : TagHelper
    {
        private readonly IServiceProvider _sp;
        [ViewContext]
        public ViewContext ViewContext { set; get; }
        public ModelExpression For { get; set; }
        public MyCustomInputTagHelper(IServiceProvider sp)
        {
            this._sp = sp;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            var originExplorer = For.ModelExplorer;
            var newModel = originExplorer.Model;
            var newExplorer = originExplorer.GetExplorerForModel(newModel);
            var newFor = new ModelExpression(For.Name, newExplorer);
            var ModelType = originExplorer.Container.Model.GetType();
            var htmlHelperType = typeof(IHtmlHelper<>).MakeGenericType(ModelType);
            var htmlHelper = this._sp.GetService(htmlHelperType) as IHtmlHelper;   // get the actual IHtmlHelper<TModel>
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);
            var vm = new PartialVM(For, htmlHelper);
            var writer = new StringWriter();
            var content = await htmlHelper.PartialAsync("~/Views/Partials/TagHelpers/MyDateInput.cshtml", vm);
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(content);
        }
    }
Now you could pass any `asp-for` expression string for the `For` property of your `TagHelper`, and it should work as expected.
**Test Case:**
Suppose we have a Dto model :
public class XModel {
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ActiveStatus{ get; set; }
}
You could render it in the following way :
html
/// the action method looks like:
///    var model = new XModel {
///        StartDate = DateTime.Now,
///        EndDate = DateTime.Now.AddYears(1),
///        ActiveStatus = "Active",
///    };
///     return View(model);
@model XModel
<my-custom-input For="StartDate" />
<my-custom-input For="EndDate" />
<my-custom-input For="ActiveStatus" />
Here's a screenshot when it renders:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/hwGf3.png
