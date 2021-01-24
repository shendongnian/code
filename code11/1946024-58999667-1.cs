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
### Using JS implementation
1. We need this form models.
    public class OrderAndCargoViewModel
    {
        public int OrderId { get; set; }
        public string PickUpAddress { get; set; }
        public string DropOffAddress { get; set; }
        public List<CargoViewModel> Cargos { get; set; }
    }
2. Next, submit the table form. Submit page code.
        <div style="float:right;">
            <table id="tb">
                <tr>
                    <th> <label  class="control-label">ID</label></th>
                    <th>  <label asp-for="@Model.Cargos.FirstOrDefault().Amount" class="control-label"></label> </th>
                    <th><label asp-for="@Model.Cargos.FirstOrDefault().CargoType" class="control-label"></label></th>
                </tr>
                @{
                    var countId = 0;
                    for (var itemCount = 0; itemCount < 3; itemCount++)
                    {
                        <tr id="trs">
                            <td>@(++countId)</td>
                            <td><input asp-for='@Model.Cargos[itemCount].Amount' class= 'form-control' /></td>
                            <td><input asp-for='@Model.Cargos[itemCount].CargoType' class='form-control' /></td>
                        </tr>
                    }
                }
            </table>
        </div>
        <input id="btnAdd" value="Add" type="button" class="btn btn-primary" onclick="btnAddClick()">
JS Code.
@section scripts{
    <script src="~/js/jquery-3.4.1/jquery-3.4.1.js" type="text/javascript"></script>
    <script src="~/js/jquery-3.4.1/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <script src="~/js/jquery-3.4.1/jquery.unobtrusive-ajax.js" type="text/javascript"></script>
    <script>
        var btnAddClick = function () {
            var trLen = $("#tb tr[id='trs']").length;
            var $lastTr = $("#tb tr[id='trs']").last();
            var tr = "<tr id='trs'>";
            tr += "<td>" + (trLen + 1) + "</td>";
            tr += "<td><input class='form-control' type='number' data-val='true' data-val-required='The Amount field is required.' id='Cargos_"+trLen+"__Amount' name='Cargos["+trLen+"].Amount' value=''></td>";
            tr += "<td><input class='form-control' type='text' id='Cargos_"+trLen+"__CargoType' name='Cargos["+trLen+"].CargoType' value=''>";
            tr += "</tr>";
            $(tr).insertAfter($lastTr);
        }
    </script>
}
Controller Code.
        [HttpPost]
        public async Task<IActionResult> CreateOrderAndCargo(OrderAndCargoViewModel model)
        {
            var order = new Order()
            {
                PickUpAddress = model.PickUpAddress,
                DropOffAddress = model.DropOffAddress
            };
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
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
3. Click [here](https://github.com/jianba/ASP.NET-Core-MVC-with-EF-Core---tutorial-series/blob/master/ContosoUniversity/Controllers/OrderController.cs) to view source codes.
