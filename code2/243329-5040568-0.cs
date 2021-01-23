    using System;
    using System.Web;
    using System.Net;
    using System.Runtime.Serialization.Json;
    
    namespace GoogleMapsSample
    {
        public class GoogleMaps
        {
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="address"></param>
            /// <returns></returns>
            public static GeoResponse GetGeoCodedResults(string address)
            {
                string url = string.Format(
                        "http://maps.google.com/maps/api/geocode/json?address={0}&region=dk&sensor=false",
                        HttpUtility.UrlEncode(address)
                        );
                var request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GeoResponse));
                var res = (GeoResponse)serializer.ReadObject(request.GetResponse().GetResponseStream());
                return res;
            }
    
    
        }
