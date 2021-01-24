    public JsonResult GetUsersFiltredPaged(string match, int page = 1, int pageSize = 5)
        {
            List<ModelDto> model = new List<ModelDto>
            {
                new ModelDto{id = "1", text  = "Option1" },
                new ModelDto{id = "2", text  = "Option2" },
                new ModelDto{id = "3", text  = "Option3" },
                new ModelDto{id = "4", text  = "Option4" },
                new ModelDto{id = "5", text  = "Option5" },
            };
            if (!string.IsNullOrWhiteSpace(match))
            {
                model = model.Where(m => m.text.Contains(match)).ToList();
            }
            ResultList<ModelDto> results = new ResultList<ModelDto>
            {
                items = model,
                total_count = 5,
            };
            return Json(results, JsonRequestBehavior.AllowGet);
        }
