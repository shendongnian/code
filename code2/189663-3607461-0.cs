        // Mocking your classes, just to check if it compiles. You don't need this.
        class Response<T> { 
            public T Code { get { return default(T); } } 
        }
        enum AResponseCode { Ok }
        enum BResponseCode { Ok }
        enum CResponseCode { Ok }
        static void LogErrorCode(string msg) { }
        private static bool ProcessErrorCode(object response)
        {
            bool isOkay;
            string errCode;
            if (!TryProcessErrorCode(response, AResponseCode.Ok, out isOkay, out errCode))
                if (!TryProcessErrorCode(response, BResponseCode.Ok, out isOkay, out errCode))
                    TryProcessErrorCode(response, CResponseCode.Ok, out isOkay, out errCode);
            if (isOkay)
            {
                return true;
            }
            string msg = "Operation resulted in error code:" + errCode;
            LogErrorCode(msg);
            return false;
        }
        // TResponseCode is automatically inferred by passing the okCode
        private static bool TryProcessErrorCode<TResponseCode>(
            object response, TResponseCode okCode, 
            out bool isOkay, out string errCode)
        {
            var resp = response as Response<TResponseCode>;
            if (resp == null)
            {
                isOkay = false;
                errCode = "UNKNOWN";
                return false;
            }
            else
            {
                isOkay = okCode.Equals(resp.Code);
                errCode = resp.Code.ToString();
                return true;
            }
        }
