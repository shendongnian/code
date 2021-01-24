    public IActionResult SaveProfessional([FromBody]JObject prof)
    {
       //select the model itself. Also do some nullchecking to prevent errors if empty
       var fooModel = prof.First;
       //select the content of the model(your actual array). Also do some nullchecking to prevent errors if empty
       var fooObjectArray= fooModel.First;
       var theDeserializedList = fooObjectArray.ToObject<List<Candidate_Educational_Info_Table>>();
       foreach (var item in theDeserializedList)
       {
          //handle the rest of what you want to do. 
          //As i see you inject the context into the objects on create but this will not be possible if you use the deserialze. 
          //Its better to pass the context on the method SaveProfessional
       }
    
        return Ok(new { suces = "result" });
    }
