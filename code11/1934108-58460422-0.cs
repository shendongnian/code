    [HttpPost]
    public JsonResult IndexTCS([FromBody] UsuarioViewModel usuarioView)
    {
        bool successToStoreData = SomeMethod(usuarioView);
        if (successToStoreData)
        {
            return Ok(usuarioView);  // indicates success
        }
        else
        {
            return BadRequest("Your error message");
        }
    }
