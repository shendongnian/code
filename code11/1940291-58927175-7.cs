      public async Task<Result> ConfirmForgotPassword(ConfirmForgotPasswordDTO confirmForgotPasswordDTO)
        {            
            using (var cognito = new AmazonCognitoIdentityProviderClient(AWSConnection.AWS_AccessKey, AWSConnection.AWS_SecretKey, AWSConnection.AWSRegion))
            {
                ConfirmForgotPasswordRequest confirmForgotPasswordRequest = new ConfirmForgotPasswordRequest();
                confirmForgotPasswordRequest.Username = ConfirmForgotPasswordDTO.UserName;
                confirmForgotPasswordRequest.ClientId = _openIdConnect.ClientId;
                confirmForgotPasswordRequest.Password = confirmForgotPasswordDTO.Password;
                confirmForgotPasswordRequest.ConfirmationCode = confirmForgotPasswordDTO.ConfirmationCode;
                ConfirmForgotPasswordResponse confirmForgotPasswordResponse = new ConfirmForgotPasswordResponse();
                string message = string.Empty;
                try
                {
                    confirmForgotPasswordResponse = await cognito.ConfirmForgotPasswordAsync(confirmForgotPasswordRequest).ConfigureAwait(false);
                }
                catch (ExpiredCodeException ex)
                {
                    message = ex.Message;
                }
                catch (InvalidPasswordException ex)
                {
                    message = ex.Message;
                }
                catch (Amazon.CognitoIdentityProvider.Model.LimitExceededException ex)
                {
                    message = ex.Message;
                }
                catch (UserNotFoundException ex)
                {
                    message = ex.Message;
                }
                catch (UserNotConfirmedException ex)
                {
                    message = ex.Message;
                }
                if (confirmForgotPasswordResponse.HttpStatusCode == HttpStatusCode.OK)
                {
                    return Result.Execute(StatusCodes.Status200OK, GlobalMessages.PasswordChangedSuccessfully, confirmForgotPasswordResponse);
                }
                return Result.Execute(StatusCodes.Status400BadRequest, message);
            }
        }
