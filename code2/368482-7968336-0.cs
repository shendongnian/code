    //Partial view displaying the Some Details
            [HttpGet]
            public ActionResult SomeDetailsPartialView()
            {
                 var ModelObjectTobePassedToPartialView=_somedetailsService.SomeMethod1()
                return PartialView("_YourPartialView", ModelObjectTobePassedToPartialView);
            }
            //Partial view for the SomeDetails, this is PostBack
            [HttpPost]
            public ActionResult SomeDetailsPartialView()
            {
               var someDetailsObject=_somedetailsService.SomeMethod2()
            
                return PartialView("_SomeDetailsPartialView", someDetailsObject);
            }
