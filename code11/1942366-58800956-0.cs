    public static IRestResponse POSTResponse( string URL, List<Parameter> Parameters )
        {
            var client = new RestClient( URL );
            var request = new RestRequest( Method.POST )
            {
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };
            foreach (var parameter in parameters)
            {
                switch( parameter.Type)
                {
                    case ParameterType.HttpHeader:
                        request.AddHeader( parameter.Name, (string)parameter.Value );
                        break;
                    case ParameterType.QueryString:
                        request.AddQueryParameter( parameter.Name, (string)parameter.Value );
                        break;
                    case ParameterType.GetOrPost:
                        request.AddParameter( parameter.Name, (string)parameter.Value );
                        break;
                }
            }
            var result = client.Post( request );
            return result;
        }
