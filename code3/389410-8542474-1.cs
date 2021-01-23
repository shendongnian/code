    public ActionResult ShowProfile()
        {
            CustomerModels cus=new CustomerModels(); 
            var list=cus.GetProfileCustomer(1); // 1 is value of ID
            return View(list);
        }
