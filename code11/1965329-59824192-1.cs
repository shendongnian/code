c#
var data = new List<HeaderDetail>()
                {
                   new HeaderDetail
                   {
                    Header =  new Header { HeaderID = 1, HeaderName = "One" },
                    Detail =  new Detail { DetailID = 1, HeaderID = 1, DetailName = "DetailOne" }
                   },
                   new HeaderDetail
                   {
                     Header =  new Header { HeaderID = 1, HeaderName = "One" },
                     Detail =  new Detail { DetailID = 2, HeaderID = 1, DetailName = "DetailTwo" }
                   },
                   new HeaderDetail
                   {
                    Header =   new Header { HeaderID = 2, HeaderName = "Two" },
                    Detail =   new Detail { DetailID = 3, HeaderID = 2, DetailName = "DetailThree" }
                   }
                };
var groupedByHeaderName = data.GroupBy(a => a.Header.HeaderName).Select(a=>a.FirstOrDefault());
or only group by header name:
c#
var groupedByHeaderName = data.GroupBy(a => a.Header.HeaderName, (key, val) => new { HeaderName = key, Data = val.ToList() });
