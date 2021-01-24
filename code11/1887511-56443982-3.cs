    <form method="post" autocomplete="off" asp-controller="Default" asp-action="Submit">
    <input type="text" name="nameOfElement" id="clientName" />
        <button id="SubmitButton" type="submit">Submit</button>
    </form>
        public class DefaultController: Controller
                {
                    [HttpPost] 
                    public IActionResult Submit([FromForm] string nameOfElement)
                    {
                        return RedirectToAction("index", "home");
                    }
                   
                }
 
