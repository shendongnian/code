    #region using statements
    
    using ResponseLibrary;
    using DataJuggler.Core.UltimateHelper;
    using System;
    using System.Collections.Generic;
    using XmlMirror.Runtime.Objects;
    using XmlMirror.Runtime.Util;
    
    #endregion
    
    namespace ResponseParserTest.Parsers
    {
    
        #region class ResponsesParser : ParserBaseClass
        /// <summary>
        /// This class is used to parse 'Response' objects.
        /// </summary>
        public partial class ResponsesParser : ParserBaseClass
        {
    
            #region Methods
    
                #region ParseResponse(string responseXmlText)
                /// <summary>
                /// This method is used to parse an object of type 'Response'.
                /// </summary>
                /// <param name="responseXmlText">The source xml to be parsed.</param>
                /// <returns>An object of type 'Response'.</returns>
                public Response ParseResponse(string responseXmlText)
                {
                    // initial value
                    Response response = null;
    
                    // if the sourceXmlText exists
                    if (TextHelper.Exists(responseXmlText))
                    {
                        // create an instance of the parser
                        XmlParser parser = new XmlParser();
    
                        // Create the XmlDoc
                        this.XmlDoc = parser.ParseXmlDocument(responseXmlText);
    
                        // If the XmlDoc exists and has a root node.
                        if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                        {
                            // Create a new response
                            response = new Response();
    
                            // Perform preparsing operations
                            bool cancel = Parsing(this.XmlDoc.RootNode, ref response);
    
                            // if the parsing should not be cancelled
                            if (!cancel)
                            {
                                // Parse the 'Response' object
                                response = ParseResponse(ref response, this.XmlDoc.RootNode);
    
                                // Perform post parsing operations
                                cancel = Parsed(this.XmlDoc.RootNode, ref response);
    
                                // if the parsing should be cancelled
                                if (cancel)
                                {
                                    // Set the 'response' object to null
                                    response = null;
                                }
                            }
                        }
                    }
    
                    // return value
                    return response;
                }
                #endregion
    
                #region ParseResponse(ref Response response, XmlNode xmlNode)
                /// <summary>
                /// This method is used to parse Response objects.
                /// </summary>
                public Response ParseResponse(ref Response response, XmlNode xmlNode)
                {
                    // if the response object exists and the xmlNode exists
                    if ((response != null) && (xmlNode != null))
                    {
                        // get the full name of this node
                        string fullName = xmlNode.GetFullName();
    
                        // Check the name of this node to see if it is mapped to a property
                        switch(fullName)
                        {
                            case "ResponseDoc.response.entitylineNumber":
    
                                // Set the value for response.EntitylineNumber
                                response.EntitylineNumber = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);
    
                                // required
                                break;
    
                            case "ResponseDoc.response.entityMark":
    
                                // Set the value for response.EntityMark
                                response.EntityMark = xmlNode.FormattedNodeValue;
    
                                // required
                                break;
    
                            case "ResponseDoc.response.entityUid":
    
                                // Set the value for response.EntityUID
                                response.EntityUID = xmlNode.FormattedNodeValue;
    
                                // required
                                break;
    
                            case "ResponseDoc.response.statusCode":
    
                                // Set the value for response.StatusCode
                                response.StatusCode = xmlNode.FormattedNodeValue;
    
                                // required
                                break;
    
                        }
    
                        // if there are ChildNodes
                        if (xmlNode.HasChildNodes)
                        {
                            // iterate the child nodes
                             foreach(XmlNode childNode in xmlNode.ChildNodes)
                            {
                                // append to this Response
                                response = ParseResponse(ref response, childNode);
                            }
                        }
                    }
    
                    // return value
                    return response;
                }
                #endregion
    
            #endregion
    
        }
        #endregion
    
    }
    
