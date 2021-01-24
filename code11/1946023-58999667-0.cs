    public class CargoViewModel
    {
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public string CargoType { get; set; }
        //Other use
        public int CargoCount { get; set; }
        public List<CargoViewModel> Cargos { get; set; }
    }
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string PickUpAddress { get; set; }
        public string DropOffAddress { get; set; }
        public int CargoCount { get; set; }
        public List<CargoViewModel> Cargos { get; set; }
    }
    public class OrdersViewModel
    {
        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }
3. When we create an order page, we need to provide the data of cargocount. When we submit the order page, we will save the existing data to the order table, jump to the cargo page, and generate cargocount input tags.
4. Next, submit the list form.
Submit page code
        <form asp-controller="Order" asp-action="CreateCargo" method="post">
                @if (Model.CargoCount != 0)
                {
                    for (int itemCount = 0; itemCount < Model.CargoCount; itemCount++)
                    {
                        <div class="row">
                            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                            <div class="form-group">
                                <div class="form-group" style="width:300px; height:auto; float:left; display:inline">
                                    <label asp-for="@Model.Cargos[itemCount].Amount" class="control-label"></label>
                                    <input asp-for="@Model.Cargos[itemCount].Amount" class="form-control" />
                                    <span asp-validation-for="@Model.Cargos[itemCount].Amount" class="text-danger"></span>
                                </div>
                                <div class="form-group" style="width:300px; height:auto; float:left; display:inline">
                                    <label asp-for="@Model.Cargos[itemCount].CargoType" class="control-label"></label>
                                    <input asp-for="@Model.Cargos[itemCount].CargoType" class="form-control" />
                                    <span asp-validation-for="@Model.Cargos[itemCount].CargoType" class="text-danger"></span>
                                </div>
                            </div>
                        </div>
                    }
                }
                <div class="form-group">
                    <input type="submit" value="Create" class="btn btn-primary" />
                </div>
            </form>
Background data processing code
        [HttpPost]  
        public async Task<IActionResult> CreateCargo(CargoViewModel  model)
        {
            var orderId = await _context.Order.Select(o => o.OrderId).MaxAsync();
            var cargos = model.Cargos;
            foreach (var item in cargos)
            {
                var cargo = new Cargo
                {
                    OrderId = orderId,
                    Amount = item.Amount,
                    CargoType = item.CargoType
                };
                await _context.AddAsync(cargo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
