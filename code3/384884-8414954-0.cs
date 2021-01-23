    private void HandleForecastResponse(IAsyncResult asyncResult)
                    {
        
                        try
                        {
        
                        // get the state information
                        ForecastUpdateState forecastState = (ForecastUpdateState)asyncResult.AsyncState;
                        HttpWebRequest forecastRequest = (HttpWebRequest)forecastState.AsyncRequest;
        
                        // end the async request
                        forecastState.AsyncResponse = (HttpWebResponse)forecastRequest.EndGetResponse(asyncResult);
        
                        Stream streamResult;
                        string newCityName = "";
                        //int newHeight = 0;
        
        
                        // get the stream containing the response from the async call
                        streamResult = forecastState.AsyncResponse.GetResponseStream();
        
                        // load the XML
                        XElement xmlWeather = XElement.Load(streamResult);
        
                        }
                        catch (Exception ex)
                        {
        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                                              {
                            MessageBox.Show("Connection Error");
        });
                        }
                }
