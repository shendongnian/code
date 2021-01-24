    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text
    /// <summary>
    /// Customized <see cref="ActionResult"/> that allows easily setting <see cref="HttpStatusCode"/>
    /// and data result object to be returned for a request.
    /// </summary>
    public class CustomActionResult : ActionResult
    {
        private static UTF8Encoding utf = new UTF8Encoding();
     
        /// <summary>
        /// Http response code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Data to return back to the user as an <see cref="object"/> of any <see cref="Type"/>
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Parameterless contructor that initializes the ActionResult with
        /// <see cref="HttpStatusCode.OK"/> as the default Response Code.
        /// </summary>
        public CustomActionResult()
        {
            StatusCode = HttpStatusCode.OK;
            Headers = new Dictionary<string, string>();
        }
        /// <summary>
        /// Constructor that initializes the ActionResult with a specified <see cref="HttpStatusCode"/>
        /// </summary>
        /// <param name="statusCode">
        /// Http response code to set for this ActionResult.
        /// </param>
        public CustomActionResult(HttpStatusCode statusCode)
            :this()
        {
            StatusCode = statusCode;
        }
        /// <summary>
        /// Constructor that initializes the ActionResult with a specified <see cref="HttpStatusCode"/>
        /// </summary>
        /// <param name="statusCode">
        /// Http response code to set for this ActionResult.
        /// </param>
        /// <param name="message">Reason phrase</param>
        public CustomActionResult(HttpStatusCode statusCode, string message)
            :this()
        {
            StatusCode = statusCode;
            Data = message;
        }
        
        private string Json
        {
            get
            {
                if(Data != null)
                {
                    if (Data.GetType() == typeof(string))
                    {
                        return Data.ToString();
                    }
                    return JsonConvert.SerializeObject(Data);
                }
                return string.Empty;
            }
        }
        public byte[] GetBuffer() => utf.GetBytes(Json);
        public Dictionary<string,string> Headers { get; private set; }
        public override void ExecuteResult(ActionContext context)
        {
            if (Headers.Count > 0)
            {
                for (int i = 0; i < Headers.Count; i++)
                {
                    var item = Headers.ElementAt(i);
                    context.HttpContext.Response.Headers.Add(item.Key, item.Value);
                }
            }
            if (!string.IsNullOrWhiteSpace(Json))
            {
                context.HttpContext.Response.ContentType = "application/json";
            }
            context.HttpContext.Response.StatusCode = (int)StatusCode;
            context.HttpContext.Response.Body.Write(GetBuffer(), 0, GetBuffer().Length);
        }
    }
