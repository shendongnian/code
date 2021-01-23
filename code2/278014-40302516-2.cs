    public class ShipDirectory
    {
        public string ShipDirectoryName { get; set; }
        public List<string> ShipNames { get; set; }
    }
    ShipDirectory myShipDirectory = new ShipDirectory()
    {
        ShipDirectoryName = "Incomming Vessels",
        ShipNames = new List<string>(){"A", "A B", "A B C"},
    }
    myShipDirectory.ShipNames.Add("Aunt Bessy");
    @Html.DropDownListFor(x => x.ShipNames, new SelectList(Model.ShipNames), "Select a Ship...", new { @style = "width:500px" })
