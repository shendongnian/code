        [HttpPatch]
        public async Task<IActionResult> PatchOne([FromBody]Patch patch)
        {
            // don't need to ModelState.isValid, it's done on binding
            
            try
            {
                var update = BsonDocument.Parse(patch.Update);
                var filter = BsonDocument.Parse(patch.Query);
                var result = await _serviceBase.UpdateOneAsync(filter, update);
                
                ...
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToJson());
            }
        }
