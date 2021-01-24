    @if (User.IsInRole("User"))
                        {
                            <li class="nav-item">
                                <a class="nav-link" href="#">user Else clause</a>
                            </li>
                        } 
                        @if (User.IsInRole("Guest"))
                        {
                            <li class="nav-item">
                                <a class="nav-link" href="#">guest Else clause</a>
                            </li>
                        }
