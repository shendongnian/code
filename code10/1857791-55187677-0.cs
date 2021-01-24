             @page "/mypage"
        @inject Microsoft.AspNetCore.Components.Services.IUriHelper UriHelper
    
        <nav>
            
            <a href="#contact">contact</a>
        
            
        </nav>
        
        
        <section>
            <h2 id="contact">contact</h2>
           
        </section>
        
    
    @functions {
        protected override void OnInit()
        {
            NavigateToElement();
            UriHelper.OnLocationChanged += OnLocationChanges;
        }
    
        private void OnLocationChanges(object sender, string location) => NavigateToElement();
    
        private void NavigateToElement()
        {
            var url = UriHelper.GetAbsoluteUri();
            var fragment = new Uri(url).Fragment;
    
            if(string.IsNullOrEmpty(fragment))
            {
                return;
            }
    
            var elementId = fragment.StartsWith("#") ? fragment.Substring(1) : fragment;
    
            if(string.IsNullOrEmpty(elementId))
            {
                return;
            }
        
            ScrollToElementId(elementId);
        }
    
        private static bool ScrollToElementId(string elementId)
        {
            return JSRuntime.Current.InvokeAsync<bool>("scrollToElementId", elementId).GetAwaiter().GetResult();
        }
    }
