    @Html.DropDownList("drpEstablishments",
                        getEstablishments().Select(s => new SelectListItem()
                            {
                              Selected = (YourConditionForSelectionHere),
                              Text = s.Description,
                              Value = s.EstablishId.ToString()
                          }),
                         new
                         {
                             @class = "dropdown form-control"
                         })
