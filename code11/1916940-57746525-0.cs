     [HttpGet]
     [Route("LongRunningProcess")]
     public async Task<IActionResult> LongRunningProcess(CancellationToken cancellationToken)
     {
       for (int i = 0; i < 10; i++)
       {
          cancellationToken.ThrowIfCancellationRequested();
           // Dummy long operation
           await Task.Factory.StartNew(() => Thread.Sleep(60000));
       }
    
        return Ok();
     }
