      public ActionResult Create(IndentmstViewData model)
        {
            model.fk_sessionUserid = Session["userID"].ToString();
            model.fk_sessionLocid = Session["fk_locid"].ToString();
            model.pk_IndentId = Convert.ToInt32(TempData["EditId"]);
        
            if (ModelState.IsValid)
            {
                XDocument doc = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
                   new XElement("XMLdata",
                   from itemdet in model.GetItemDetails
                   select new XElement("ItemDetails",
                   new XElement("fk_itemid", itemdet.fk_ItemId),
                   new XElement("qty", itemdet.Qty),
                   new XElement("balqty", itemdet.indbalqty),
                   new XElement("estimatedcost", itemdet.EstimatedCost),
                   new XElement("partno", itemdet.PartNo),
                   new XElement("itemdesc", itemdet.itemDesc),
                   new XElement("fk_indentid", model.pk_IndentId))));
        
                model.doc = doc.ToString();
        
                if (model.pk_IndentId == 0)
                {
                    _indent_mstService.Save(model.ADTO());
                }
                else
                {
                    _indent_mstService.Update(model.ADTO());
                }
    
                return JSON(new
                {
                    ResultStatus=false,
                    Message="Here Success Message Text...",
                    Result=new 
                    {
                        fk_sessionUserid= model.fk_sessionUserid,
                        fk_sessionLocid=model.fk_sessionLocid,
                        pk_IndentId=model.pk_IndentId,
                        Doc=model.doc
                    }
                });
        
            }
            else
            {
                return JSON(new
                {
                    ResultStatus=false,
                    Message="Here Error Text...",
                    Result=new 
                    {
                        IndentDate= DateTime.Now.ToString("dd/MM/yyyy").Replace("-", "/").ToString(),
                        GetMenuData= GetMenuByUser(),
                        GetItems=_HomeService.GetItems().ToList(),
                        IndentNo=_indent_mstService.GetAutoIndentNo(fk_locid).FirstOrDefault()
                    }
                });
            }
        }
