        public ActionResult EstoqueOpcional()
        {
            return PartialView(new EstoqueOpcional());
        }
        [HttpPost]
        public bool EstoqueOpcionalCreate(EstoqueOpcional estoqueOpcional, string PageToken)
        {
            List<EstoqueOpcional> estoqueOpcionals = new List<EstoqueOpcional>();
            if (TempData["EstoqueOpcional" + PageToken] != null)
                estoqueOpcionals.AddRange((List<EstoqueOpcional>)TempData["EstoqueOpcional" + PageToken]);
            if (estoqueOpcionals.Where(x => x.DsOpcional == estoqueOpcional.DsOpcional).Count() == 0)
                estoqueOpcionals.Add(estoqueOpcional);
            TempData["EstoqueOpcional" + PageToken] = estoqueOpcionals;
            return true;
        }
        public bool RemoverOpcional(string opcional, string PageToken)
        {
            try
            {
                if (TempData["EstoqueOpcional" + PageToken] != null)
                {
                    List<EstoqueOpcional> estoqueOpcionals = (List<EstoqueOpcional>)TempData["EstoqueOpcional" + PageToken];
                    estoqueOpcionals.RemoveAll(x => x.DsOpcional == opcional);
                    TempData["EstoqueOpcional" + PageToken] = estoqueOpcionals;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
