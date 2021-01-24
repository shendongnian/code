html
  data: JSON.stringify({ Model : Itemslists}),
should be
html
  data: JSON.stringify({ Model : itemlists}),
Looks like it was just a typo with the name of the array.
Working code:
html
@{
    ViewBag.Title = "Home Page";
}
<script src="https://code.jquery.com/jquery-3.4.1.min.js"
        integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo="
        crossorigin="anonymous"></script>
    $("body").on("click", "#btnSave", function () {
        //Loop through the Table rows and build a JSON array.
        var itemlists = new Array();
        $("#tblAttachShip TBODY TR").each(function () {
            var row = $(this);
            var itemList = {};
            itemList.itemlineId = row.find("TD").eq(0).html();
            itemList.shipmentID = document.getElementById("txtShipmentID").value
            itemList.containerID = row.find("TD").eq(1).html();
            itemList.containerType = row.find("TD").eq(2).html();
            itemlists.push(itemList);
        });
        //Send the JSON array to Controller using AJAX.
        $.ajax({
            url: './Home/Create',
            type: 'POST',
            data: JSON.stringify({ Model: itemlists }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert(r + " record(s) inserted.");
            },
            error: function (r) {
                alert(JSON.stringify(r));
            }
        });
    });
<input type="text" id="txtShipmentID" />
<table id="tblAttachShip">
    <tbody>
        <tr>
            <td>aaa</td>
            <td>aa</td>
            <td>a</td>
        </tr>
        <tr>
            <td>bbb</td>
            <td>bb</td>
            <td>b</td>
        </tr>
    </tbody>
</table>
<button id="btnSave">Save</button>
csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        [HttpPost]
        public JsonResult Create(List<Model> Model)
        {
            return Json(new { Message = "Success" });
        }
    }
    public class Model
    {
        public string itemlineId { get; set; }
        public string shipmentID { get; set; }
        public string containerID { get; set; }
        public string containerType { get; set; }
    }
}
