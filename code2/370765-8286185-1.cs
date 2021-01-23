        [HttpPost]
        public ActionResult InfrastrukturaDelete(int[] InfrastukturaID)
        {
            foreach (int item in InfrastukturaID)
            {
                    Infrastruktury infrastruktura = naukaRepository.GetInfrastruktura(item);
                    naukaRepository.DeleteInfrastruktura(infrastruktura);
                    naukaRepository.Save();
            }
            return Content("OK");
        }
