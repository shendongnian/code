    @{
            bool isUserConnected = string.IsNullOrEmpty(Model.CreatorFullName);
            if (isUserConnected)
            { // meaning that the viewing user has not been saved
                <div>
                    <div> click to join us </div>
                    <a id="login" href="javascript:void(0);" style="display: inline; ">join</a>
                </div>
            }
        }
