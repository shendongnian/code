     public IActionResult PostOpenBase64([FromBody]Open64Request request)
        {
            string param = Base64.DecodeFromBase64(request.b64);
            EvaluationParameter ep = JsonConvert.DeserializeObject<EvaluationParameter>(param);
            OpenRequest or = new OpenRequest();
            FindRequest fr = new FindRequest();
            or.Parameters = ep;
            fr.Parameters = ep;
            IActionResult ret = Post(fr);
            var contentResult = ret as OkObjectResult;
            FindResponse response = (FindResponse)contentResult.Value;
            if (response.MustOpen || response.EvaluationId == 0)
            {
                Post(or); //Open
                ret = Post(fr); //Find
            }
            return ret;
        }
