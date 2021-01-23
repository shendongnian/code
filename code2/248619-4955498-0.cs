        public ActionResult GetRam(Guid productId)
        {
            var cpu = Products.First(x => x.Id == productId);
            switch (cpu.Attribute)
            {
                case "1366":
                    ViewData["Ram"] = Products.Where(x => x.Attribute == "TrippleChannel").ToArray();
                    break;
                case "1155":
                    ViewData["Ram"] = Products.Where(x => x.Attribute == "DualChannel").ToArray();
                    break;
            }
            return PartialView("_RamList");
        }
