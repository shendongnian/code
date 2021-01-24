    @Html.DropDownListFor(model => model.SelectedStatus, new List<SelectListItem>
                                                                      { new SelectListItem(){ Text="NEW", Value = "NEW" },
                                                                        new SelectListItem(){ Text="PAID", Value = "PAID" },
                                                                        new SelectListItem(){ Text="PENDING", Value = "PENDING" },
                                                                        new SelectListItem(){ Text="FAULT", Value = "FAULT" },
                                                                        new SelectListItem(){ Text="PROCESS", Value = "PROCESS" }
                                                                      }, "Select Status", new { @class = "form-control " })
