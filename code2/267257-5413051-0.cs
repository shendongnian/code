    namespace RestServicePublishing
    {
        [ServiceContract]
        public interface IRestService
        {
            [OperationContract(Name="GetXML")]
            [WebGet(UriTemplate = "/{param1}/{param2}")]
            List<Person> GetXML(string param1, string param2);
        }
    }
