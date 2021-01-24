                            @if (o.Person.FirstName == null || o.Person.FirstName == "" || o.Person.FirstName == "NOT")
                            {
                                <td>Not Found</td>
                            }
                            else
                            {
                                <td>@Html.ActionLink(o.Person.FirstName, "Detail", "Player", new { selectedPlayerID = o.Person.IDPerson, referringController = "ValidationHistory" }, null)</td>
                            }
