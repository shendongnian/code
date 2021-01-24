  public ActionResult Details(Int id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        List<SingleView> singleView = db.SingleViews.count > 0 ?
                                 db.SingleViews.where(a => a.id == id).tolist() : null ;
        if (singleView == null)
        {
            return HttpNotFound();
        }
        return View(singleView);
    }
**View**
    @model  List<MinetSingleView.Models.SingleView>
    @{
                    @foreach (var item in Model)
                    {
                        <tr>
                            <td>@Html.DisplayFor(model => model.Client)</td>
                            <td> @Html.DisplayFor(model => model.InsurerName)</td>
                            <td>Product Type</td>
                            <td>@Html.DisplayFor(model => model.PolicyType)</td>
                            <td>@Html.DisplayFor(model => model.RenewalDate)</td>
                            <td>@Html.DisplayFor(model => model.PolicyNo)</td>
                            <td>@Html.DisplayFor(model => model.Telephone)</td>
                            <td>@Html.DisplayFor(model => model.Status)</td>
                        </tr>
                    }
           }
