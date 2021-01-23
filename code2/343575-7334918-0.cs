    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Bloomberglp.Blpapi;
    
    namespace BbServerApiTool
    {
        public class GetFields : GetBloombergFields
        {
            private static readonly Name EXCEPTIONS = new Name("exceptions");
            private static readonly Name FIELD_ID = new Name("fieldId");
            private static readonly Name REASON = new Name("reason");
            private static readonly Name CATEGORY = new Name("category");
            private static readonly Name DESCRIPTION = new Name("description");
            private static readonly Name ERROR_CODE = new Name("errorCode");
            private static readonly Name SOURCE = new Name("source");
            private static readonly Name SECURITY_ERROR = new Name("securityError");
            private static readonly Name MESSAGE = new Name("message");
            private static readonly Name RESPONSE_ERROR = new Name("responseError");
            private static readonly Name SECURITY_DATA = new Name("securityData");
            private static readonly Name FIELD_EXCEPTIONS = new Name("fieldExceptions");
            private static readonly Name ERROR_INFO = new Name("errorInfo");
    
            public override List<List<string>> GetBbFields(string[] tickers, string[] fieldsParam)
            {
                string serverHost = System.Configuration.ConfigurationManager.AppSettings["Host"];
                int serverPort = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);
    
                var sessionOptions = new SessionOptions {ServerHost = serverHost, ServerPort = serverPort};
    
                var session = new Session(sessionOptions);
                session.Start();
                session.OpenService("//blp/refdata");
                Service refDataService = session.GetService("//blp/refdata");
                Request request = refDataService.CreateRequest("ReferenceDataRequest");
                Element securities = request.GetElement("securities");
                Element fields = request.GetElement("fields");
                request.Set("returnEids", true);
    
                foreach (var ticker in tickers)
                {
                    securities.AppendValue(ticker);
                }
    
                foreach (var field in fieldsParam)
                {
                    fields.AppendValue(field);
                }
    
                var cID = new CorrelationID(1);
                session.Cancel(cID);
                Results = new List<List<string>>();
                session.SendRequest(request, cID);
    
                while (true)
                {
                    Event eventObj = session.NextEvent();
                    processEvent(eventObj, session, fieldsParam);
                    if (eventObj.Type == Event.EventType.RESPONSE)
                    {
                        return Results;   
                    }
                }
            }
    
            protected override string GetName()
            {
                return "BbServerApiTool";
            }
    
            private void processEvent(Event eventObj, Session session, string[] fields)
            {
                switch (eventObj.Type)
                {
                    case Event.EventType.RESPONSE:
                    case Event.EventType.PARTIAL_RESPONSE:
                        processRequestDataEvent(eventObj, session, fields);
                        break;
                    default:
                        processMiscEvents(eventObj, session);
                        break;
                }
            }
    
            private void processMiscEvents(Event eventObj, Session session)
            {
                foreach (Message msg in eventObj.GetMessages())
                {
                    switch (msg.MessageType.ToString())
                    {
                        case "RequestFailure":
                            Element reason = msg.GetElement(REASON);
                            string message = string.Concat("Error: Source-", reason.GetElementAsString(SOURCE),
                                ", Code-", reason.GetElementAsString(ERROR_CODE), ", category-", reason.GetElementAsString(CATEGORY),
                                ", desc-", reason.GetElementAsString(DESCRIPTION));
                            throw new ArgumentException(message);
                        case "SessionStarted":
                        case "SessionTerminated":
                        case "SessionStopped":
                        case "ServiceOpened":
                        default:
                            break;
                    }
                }
            }
            private void processRequestDataEvent(Event eventObj, Session session, string[] fields)
            {
                foreach (Message msg in eventObj.GetMessages())
                {
                    if (msg.MessageType.Equals(Name.GetName("ReferenceDataResponse")))
                    {
                        Element secDataArray = msg.GetElement(SECURITY_DATA);
                        int numberOfSecurities = secDataArray.NumValues;
                        for (int index = 0; index < numberOfSecurities; index++)
                        {
                            Element secData = secDataArray.GetValueAsElement(index);
                            Element fieldData = secData.GetElement("fieldData");
    
                            if (secData.HasElement(FIELD_EXCEPTIONS))
                            {
                                // process error
                                Element error = secData.GetElement(FIELD_EXCEPTIONS);
                                if (error.Elements.Count() > 0)
                                {
                                    Element errorException = error.GetValueAsElement(0);
                                    Element errorInfo = errorException.GetElement(ERROR_INFO);
                                    string message = errorInfo.GetElementAsString(MESSAGE);
                                    throw new ArgumentException(message);
                                }
                            }
    
                            var list = new List<string> { secData.GetElement("security").GetValueAsString() };
                            if (secData.HasElement(SECURITY_ERROR))
                            {
                                Element error = secData.GetElement(SECURITY_ERROR);
                                string errorMessage = error.GetElementAsString(MESSAGE);
                                //                            throw new ArgumentException(errorMessage);
                                //TODO Log
                                logger.WriteLine("Couldn't get a value for " + secData.GetElement("security").GetValueAsString());
                                foreach (var field in fields)
                                {
                                    list.Add("N/A");
                                }
                            }
                            else
                            {
                                foreach (var field in fields)
                                {
                                    Element item = fieldData.GetElement(field);
                                    list.Add(item.IsNull ? "N/A" : item.GetValueAsString());
                                }
                            }
                            Results.Add(list);
                        }
                    }
                }
            }
        }
    }
