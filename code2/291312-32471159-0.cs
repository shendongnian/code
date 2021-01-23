    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace cSharpServer
    {
        public interface IClientRequest
        {        
            /// <summary>
            /// this needs to be set, otherwise the server will not beable to handle the request.
            /// </summary>
            byte IdType { get; set; } // This is used for Execution.
            /// <summary>
            /// handle the process by the client.
            /// </summary>
            /// <param name="data"></param>
            /// <param name="client"></param>
            /// <returns></returns>
            byte[] Process(BinaryBuffer data, Client client);
        }
    }
