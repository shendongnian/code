Task<IActionResult>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista_coutas = await _conexion.GetCuotas();
    
            return Ok(lista_coutas);
        }
