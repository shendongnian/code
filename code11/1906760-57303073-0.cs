C#
                <li class="nav-header text-center pb-1 text-white"><strong>Menu de Navegação</strong></li>
                @foreach (var item in Model.Items)
                {
                    @* here for the parent menu item*@
                    <li class=@(ViewContext.RouteData.Values["Controller"].ToString().ToLower() == item.Name.ToLower() ? "nav-item has-treeview active" : "nav-item has-treeview">
                        <a href="@item.Url" class="nav-link custom-sidebar-link">
                            @Html.Raw(@item.Icon)
                            <p class="text-white">
                                @item.Nome
                                @if (item.SubItems != null)
                                {
                                    <i class="fas fa-angle-left right"></i>
                                }
                            </p>
                        </a>
                        @if (item.SubItems != null)
                        {
                            <ul class="nav nav-treeview">
                                @foreach (var subItem in item.SubItems)
                                {
                                    @* here for the child menu item*@
                                    <li class=@(ViewContext.RouteData.Values["Action"].ToString().ToLower() == item.Url.Split('/').Last().ToLower() ? "nav-item active" : "nav-item">
                                        <a href="@subItem.Url" class="nav-link">
                                            @Html.Raw(@subItem.Icon)
                                            <p>
                                                @subItem.Nome
                                            </p>
                                        </a>
                                    </li>
                                }
                            </ul>
                        }
                    </li>
                }
            </ul>
        </nav>
I've used `.ToString().ToLower()` because I was testing before posting, you might not need them
