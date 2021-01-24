        public ActionResult Insert([FromBody]dynamic qaEval)
                {            
                    
                        var objModel1 = Newtonsoft.Json.JsonConvert.DeserializeObject(qaEval.ToString());
        
                        var objModel = Newtonsoft.Json.JsonConvert.SerializeObject(objModel1.qaEval);
        
        QAEvaluationModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.QAEvaluationModel>(objModel);
    
    qaEvaluationRepository.Add(model);
    
    return Ok(new Models.APIResponse
                        {
                            HasError = false,
                            Message = "Success",
                            Content = null
                        });
        }
