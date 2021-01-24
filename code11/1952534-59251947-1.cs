        [HttpPost]
            public ActionResult GetData(DateTime param1,DateTime param2)
            {
                ExampleService es= new ExampleService ();
                ExampleViewModel evm = new ExampleViewModel ();
               evm.ListForChart = es.GetWeekly(param1,param2);
               evm.ListForChart2 = es.GetMothly(param1,param2);
    ..
    return PartialView("your_partialviewname", evm);
    }
