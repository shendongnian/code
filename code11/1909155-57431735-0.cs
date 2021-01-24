csharp
// GET: Questions/Create
        public IActionResult Create(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            PopulateId(id);
            return View();
        }
The fix:
csharp
// GET: Questions/Create
        public IActionResult Create(int? questionGroupId)
        {
            if (questionGroupId== null) {
                return NotFound();
            }
            PopulateId(questionGroupId);
            return View();
        }
Since the default startup had this template:
csharp
app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
**In conclusion:**
This was quite a simple mistake, as I was using poor naming. Default create get methods don't have an ID, but since I needed to do some stuff with the parent object on the page, I had to pass it to my view, and .Net was setting my questionId (child) to the questionGroupId (parent).
I hope this helps anyone else who runs into this issue.
Thanks to commenters for the help 
