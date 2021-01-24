        @code{
           [Parameter]
           public string AccessToken { get; set; }
           protected override async Task OnAfterRenderAsync(bool firstRender)
           {
               if (firstRender)
                {
                    await tokenStorage.SetTokenAsync(AccessToken);
                }
           }
         }
