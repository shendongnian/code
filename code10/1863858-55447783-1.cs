    public class MyController: Controller
    {
        [HttpGET]
        public async Task<IActionResult> Create()
        {
            var car = await _MyRepository.GetAllCarTypesAsync();
            var model = _mapper.Map<List<CarsVM>>(car);
            return View(model);
        }
    }
