    #region using statements
    
    using ResponseLibrary;
    using XmlMirror.Runtime.Objects;
    
    #endregion
    
    namespace ResponseParserTest.Parsers
    {
    
        #region class ResponsesParser : ParserBaseClass
        /// <summary>
        /// This class is used to parse 'Response' objects.
        /// </summary>
        public partial class ResponsesParser : ParserBaseClass
        {
    
            #region Events
    
                #region Parsing(XmlNode xmlNode)
                /// <summary>
                /// This event is fired BEFORE the collection is initialized.
                /// </summary>
                /// <param name="xmlNode"></param>
                /// <returns>True if cancelled else false if not.</returns>
                public bool Parsing(XmlNode xmlNode)
                {
                    // initial value
                    bool cancel = false;
    
                    // Add any pre processing code here. Set cancel to true to abort parsing this collection.
    
                    // return value
                    return cancel;
                }
                #endregion
    
                #region Parsing(XmlNode xmlNode, ref Response response)
                /// <summary>
                /// This event is fired when a single object is initialized.
                /// </summary>
                /// <param name="xmlNode"></param>
                /// <param name="response"></param>
                /// <returns>True if cancelled else false if not.</returns>
                public bool Parsing(XmlNode xmlNode, ref Response response)
                {
                    // initial value
                    bool cancel = false;
    
                    // Add any pre processing code here. Set cancel to true to abort adding this object.
    
                    // return value
                    return cancel;
                }
                #endregion
    
                #region Parsed(XmlNode xmlNode, ref Response response)
                /// <summary>
                /// This event is fired AFTER the response is parsed.
                /// </summary>
                /// <param name="xmlNode"></param>
                /// <param name="response"></param>
                /// <returns>True if cancelled else false if not.</returns>
                public bool Parsed(XmlNode xmlNode, ref Response response)
                {
                    // initial value
                    bool cancel = false;
    
                    // Add any post processing code here. Set cancel to true to abort adding this object.
    
                    // return value
                    return cancel;
                }
                #endregion
    
            #endregion
    
        }
        #endregion
    
    }
    
