      @if (User.Identity.IsAuthenticated)
      {
          // Normal case
      }
      else
      {
          @Html.Partial("Login")
      }
