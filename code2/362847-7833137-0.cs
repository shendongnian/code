        public ActionResult Confirmation(Order Order)
        {
            if (Session["CompanyID"] == null)
            {
                string url = Request.Url.Host;
                if (Request.Url.Port != null)
                {
                    url = url + Request.Url.Port;
                }
                url = url + "/signin.asp";
                return RedirectToAction(<YOUR ACTION>);
            }
            else
            {
                int userID = (int)Session["CompanyID"];
                Corp_User User = Repository.CorpUserDetails(userID);
                return View(new OrderLocation { Order = Order, Location = WhygoRepository.RoomDetails(Order.roomId).First(), Corp_User = User });
            }
        }
