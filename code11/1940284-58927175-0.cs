    public async Task<Result> ForgotPassword(string email)
        {
            using (var cognito = new AmazonCognitoIdentityProviderClient(AWSConnection.AWS_AccessKey, AWSConnection.AWS_SecretKey, AWSConnection.AWSRegion))
            {
                ListUsersRequest listUsersRequest = new ListUsersRequest();
                listUsersRequest.UserPoolId = _openIdConnect.MetadataAddress.Split("/")[3];
                listUsersRequest.Filter = string.Format("email = \"{0}\"", email.ToLower()); //Get Data by Email from UserPool
                ListUsersResponse listUsersResponse = await cognito.ListUsersAsync(listUsersRequest);
                if (listUsersResponse.Users.Any())
                {
                    ForgotPasswordRequest forgotPasswordRequest = new ForgotPasswordRequest();
                    forgotPasswordRequest.Username = listUsersResponse.Users.Select(x => x.Username).FirstOrDefault();
                    forgotPasswordRequest.ClientId = _openIdConnect.ClientId;
                    ForgotPasswordResponse forgotPasswordResponse = await cognito.ForgotPasswordAsync(forgotPasswordRequest).ConfigureAwait(false);
                    return Result.Execute(StatusCodes.Status200OK, GlobalMessages.FETCH_SUCCESS, forgotPasswordResponse);
                }
                else
                {
                    return Result.Execute(StatusCodes.Status200OK, GlobalMessages.UserNotFound);
                }
            }
        }
