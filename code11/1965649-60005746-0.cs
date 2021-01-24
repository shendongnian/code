    interface IStage{
        byte StatusIndicatorId { get; set; }
        string StatusInfo { get; set; }
        decimal StageCompletion { get; set; }
        bool IsMandatory { get; set; }
    }
     public partial class D1Stage : EntityBase, IStage
     {
        [DisplayName("Status Indicator")]
        public byte StatusIndicatorId { get; set; }
    [DisplayName("Status Info")]
    public string StatusInfo { get; set; }
    [DisplayName("Completed %")]
    [SCIRange(0, 100)]
    public decimal StageCompletion { get; set; }
    [DisplayName("Is Step Mandatory")]
    public bool IsMandatory { get; set; }
    }
@View
    @model IStage
    @{
    IEnumerable<SelectListItem> StatusIndicators = ViewBag.StatusIndicators;
    }
   @using (Html.BeginForm("", "", FormMethod.Post, new { enctype = "multipart/form-data", 
   @class = "form form-horizontal" }))
    {
       <div class="form-body">
           @Html.AntiForgeryToken()
           @Html.HiddenFor(model => model.Id)
           @Html.HiddenFor(model => model.Report.Id)
           <div class="form-group">
               @Html.SCILabelFor(model => model.StatusIndicatorId, new { @class = "col-md-1 control-label" })
                  <div class="input-group col-md-4">
                   @Html.DropDownListFor(model => model.StatusIndicatorId, new SelectList(StatusIndicators, "Value", "Text"), "None", new { @class = "form-control" })
                   @Html.ValidationMessageFor(model => model.StatusIndicatorId, "", new { @class = "text-danger" })
               </div>
           </div>
           <div class="form-group">
               @Html.SCILabelFor(model => model.StatusInfo, new { @class = "col-md-1 control-label" })
            <div class="input-group col-md-4">
                @Html.TextAreaFor(model => model.StatusInfo, new { @class = "form-control" })
                @Html.ValidationMessageFor(model => model.StatusInfo, "", new { @class = "text-danger" })
            </div>
        </div>
        <div class="form-group">
            @Html.SCILabelFor(model => model.StageCompletion, new { @class = "col-md-1 control-label" })
            <div class="input-group col-md-4">
                @Html.SCINumericTextBoxFor(model => model.StageCompletion, new { @class = "form-control sliderrangemintext", @style = "width:100px" })
                <div class="sliderrangemin" id="slider-range-min" style="margin-top:50px"></div>
            </div>            
        </div>
        <div class="form-group">
            @Html.SCILabelFor(model => model.IsMandatory, new { @class = "col-md-1 control-label" })
            <div class="input-group col-md-4">
                <div class="input-group" style="width:100%">
                    @Html.DropDownListFor(model => model.IsMandatory, new List<SelectListItem>() { new SelectListItem { Text = "No", Value = "false" }, new SelectListItem { Text = "Yes", Value = "true", Selected = true } }, htmlAttributes: new { @class = "form-control" })
                    @Html.ValidationMessageFor(model => model.IsMandatory, "", new { @class = "text-danger" })
                </div>
            </div>
        </div>
    </div>
    }
In this way there's only one view.
