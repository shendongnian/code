        public static async Task<TResponse> ProcessJson<TInput, TResponse>(TInput input,string api,string apiAction = ApiConstant.CallPost)
            {
                // Process Input Type to string
                var jsonInput = FetchJsonInput(input);
    
                // Execute Api call Async
                var httpResponseMessage = await MakeApiCall(jsonInput, api, apiAction);
    
                // Process Byte[] and Fetch final result
                return await FetchJsonResult<TResponse>(httpResponseMessage);
            }
 
