     public static List<Models.OrderList> RetrieveOrderList(string host, List<Models.FilterCondition> filter)
        {
            string sResult = HttpHelper.httpPost(host + "api/Order/RetrieveOrderList", Newtonsoft.Json.JsonConvert.SerializeObject(filter));
            Models.ApiResult mResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ApiResult>(sResult);
            if (mResult.Status == 0)
                throw new Exception(mResult.Message);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.OrderList>>(mResult.Data);
        }
