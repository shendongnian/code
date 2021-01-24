        [HttpPost]
        [Route("/InsertIncluding")]
        public IActionResult PostIncluding([FromBody]ChannelTypeDtoIncluding model)
        {
            if (string.IsNullOrEmpty(model.Id))
                return new NotFoundResult();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ChannelType data = _mapper.Map<ChannelTypeDtoIncluding, ChannelType>(source: model);
            _context.ChannelType.Add(data);
            _context.SaveChanges();
            return new OkObjectResult(_mapper.Map<ChannelType, ChannelTypeDtoIncluding>(source: data));
        }
