       [AllowAnonymous]
       [Route("GetCommunesFromCP/{codePostal}")
        public IActionResult GetCommunesFromCP(string codePostal)
        {
            IList<CommuneDto> resCommunes = _communeService.GetCommunesFromCP(codePostal);
    
            if (resCommunes == null || resCommunes.Count == 0)
                return NotFound();
            else
                return Ok(resCommunes);
        }
