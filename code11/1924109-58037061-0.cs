if (pingResponse != null && pingResponse.RoundtripTime < proxyTimeOut)
                {
                    pingResponseTime = pingResponse.RoundtripTime;
                    return true;
                }
with
if (pingResponse.Status == IPStatus.Success && pingResponse.RoundtripTime < proxyTimeOut)
                    {
                        pingResponseTime = pingResponse.RoundtripTime;
                        return true;
                    }
Although not all is bad as the use "Dai" informed me I should be using the "Using" tags and that has sped up my proxy checking significantly, thanks!
