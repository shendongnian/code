            System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            var requestFromPost = reader.ReadToEndAsync();
            dynamic json = JsonConvert.DeserializeObject(requestFromPost.Result);
            string intent = json.queryResult.intent.name;
            return new ContentResult { Content = requestFromPost.Result, ContentType = "application/json" };
        }
