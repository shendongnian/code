    [HttpPost]
    public async Task<ActionResult<Leaks>> PostLeaks([FromForm]Leaks leaks)
    {
       // you must receive the file in leaks.Image.
       // your logic to convert file to bytes.
    }
