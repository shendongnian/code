    @using System.Security.Principal
    
    <ul class="nav navbar-nav navbar-right loginpartial">
    @if (User.Identity.IsAuthenticated)
    {
            <li class="nav-item">
                <span class="navbar-text text-dark">Hello @User.Identity.Name.Substring(0,User.Identity.Name.IndexOf("@"))!</span>
            </li>
