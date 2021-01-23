      [ServiceContract]
      public interface IPersonas
      {
          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate="/getPeople")]
          Persona[] getPeople();
      }
