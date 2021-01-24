    [Route("{id:int}")]
                [HttpPatch]
                public async Task<IActionResult> RemoveMeAsync(int id)
                {
                    bool commandResult = false;
        
                    try
                    {
                        commandResult = await _mediator.Send(new RemoveMeCommand(id));
                        return NoContent();
                    }
                    catch (NotFoundException)
                    {
                        return NotFound(id);
                    }
                }
