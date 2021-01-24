    public Stream GetStateDataAsStream()
            {
                var state = new StateData
                {
                    DeviceInfo = _deviceInfo,
                    IsAuthenticated = IsUserAuthenticated,
                    UserSession = _user,
                    Cookies = _httpRequestProcessor.HttpHandler.CookieContainer
                };
                return SerializationHelper.SerializeToStream(state);
            }
