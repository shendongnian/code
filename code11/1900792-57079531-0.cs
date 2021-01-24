    foreach (WCFService service in _servicesToProbe)
            {
                ProbeResults probeResult = new ProbeResults();
                var watch = Stopwatch.StartNew();
                IChannelFactory<IRequestChannel> factory = service.ServiceBinding.BuildChannelFactory<IRequestChannel>(new BindingParameterCollection());
                factory.Open();
                EndpointAddress address = service.EndpointURL;
                IRequestChannel irc = factory.CreateChannel(address);
                try
                {
                    using (irc as IDisposable)
                    {
                        irc.Open();
                        StringReader sr = new StringReader(String.Format(@"<{0} xmlns='http://tempuri.org/'><composite xmlns:a='http://schemas.xmlsoap.org/soap/envelope/' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'><a:value>10</a:value></composite></{0}>", service.ActionName));
                        XmlReader reader = XmlReader.Create(sr);
                        Message m = Message.CreateMessage(MessageVersion.Soap11, String.Format("http://tempuri.org/{0}/{1}", service.InterfaceName, service.ActionName), reader);
                        Message ret = irc.Request(m);
                        reader.Close();
                        factory.Close();
                        probeResult = ProcessResponse(ret, service);
                        _probeResults.Add(probeResult);
                    }
                }
                catch (Exception ex)
                {
                    factory.Close();
                    probeResult = new ProbeResults(service.ServiceName, false, ex.Message);
                    _probeResults.Add(probeResult);
                }
                watch.Stop();
                probeResult.TimeElapsed = watch.ElapsedMilliseconds;
            }
   
