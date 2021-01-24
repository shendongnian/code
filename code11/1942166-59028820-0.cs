    string uriBase = Environment.GetEnvironmentVariable("UriBaseWorkdayAbsenceManagement");
            string user = Environment.GetEnvironmentVariable("WorkdayUsername");
            string pass = Environment.GetEnvironmentVariable("WorkdayPassword");
            string xml;
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    XmlSerializerNamespaces names = new XmlSerializerNamespaces();
                    names.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                    names.Add("bsvc", "urn:com.workday/bsvc");
                    XmlSerializer cs = new XmlSerializer(typeof(Envelope));
                    var myEnv = new Envelope()
                    {
                        Header = new EnvelopeHeader()
                        {
                            Security = new Security()
                            {
                                UsernameToken = new SecurityUsernameToken()
                                {
                                    Username = user,
                                    Password = new SecurityUsernameTokenPassword()
                                    {
                                        Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText",//update type to match your case
                                        Value = pass
                                    }
                                }
                            }
                        },
                        Body = new EnvelopeBody()
                        {
                            get_Time_Off_Plan_Balances_RequestType = new WorkDayAbsenceServiceReference.Get_Time_Off_Plan_Balances_RequestType()
                            {
                                Request_Criteria = new WorkDayAbsenceServiceReference.Time_Off_Plan_Balance_Request_CriteriaType()
                                {
                                    Employee_Reference = new WorkDayAbsenceServiceReference.WorkerObjectType()
                                    {
                                        ID = new WorkDayAbsenceServiceReference.WorkerObjectIDType[]
                                        {
                                            new WorkDayAbsenceServiceReference.WorkerObjectIDType
                                            {
                                                type = "Employee_ID",
                                                Value = workerId
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    };
                    cs.Serialize(writer, myEnv, names);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(ms);
                    xml = sr.ReadToEnd();
                }
            }
            SoapEnvelope responseEnvelope = null;
            using (var client = SoapClient.Prepare().WithHandler(new DelegatingSoapHandler()
            {
                OnHttpRequestAsyncAction = async (z, x, y) =>
                {
                    x.Request.Content = new StringContent(xml, Encoding.UTF8, "text/xml");
                }
            }))
            {
                responseEnvelope = client.SendAsync(uriBase, "action", SoapEnvelope.Prepare()).Result;
            }
