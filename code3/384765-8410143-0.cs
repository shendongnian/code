     //get the filtered viewmodel data
     $.get('@Url.Action("FilterPersons")', function (data) { 
          //pass viewmodel to get rendered view             
          $("#PersonGrid").load("/Person/GetPersonsView"
             data.Persons, function () {
               //callback
          });
          //pass viewmodel to get rendered view       
          $("#PersonRollupGrid").load("/Person/GetPersonsRollUpView",
             data.PersonsRollup, function () {
               //callback
          });
     });
       
      public ActionResult FilterPersons(string someFilteredData)
      {
           ....
           return JsonResult(pvm, JsonRequestBehavior.AllowGet);
      }
    
      public ActionResult GetPersonsView(Persons persons)
      {   
          return PartialView("_Persons", persons);
      }
    
      public ActionResult GetPersonsRollUpView(PersonRollup personRollup)
      {   
          return PartialView("_PersonsRollUp", personRollup);
      }
