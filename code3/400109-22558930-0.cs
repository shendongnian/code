    public ActionResult AuthorizeResponse(bool isApproved)
        {
            var pendingRequest = this.authorizationServer.ReadAuthorizationRequest();
            IDirectedProtocolMessage response;
            if (isApproved)
            {
                //TODO Save authorization here
                response = this.authorizationServer.PrepareApproveAuthorizationRequest(pendingRequest, SessionManager.SsoUser.Username);
            }
            else
            {
                response = this.authorizationServer.PrepareRejectAuthorizationRequest(pendingRequest);
                // Here I set the error by myself
                var errorResponse = response as EndUserAuthorizationFailedResponse;
                errorResponse.Error = "access_denied";
                errorResponse.ErrorDescription = "User rejected the authorization.";
                // And return errorResponse instead of simple response
                return this.authorizationServer.Channel.PrepareResponse(errorResponse).AsActionResult();
            }
            return this.authorizationServer.Channel.PrepareResponse(response).AsActionResult();
        }
